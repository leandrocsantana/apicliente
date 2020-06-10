using APICliente.Context;
using APICliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APICliente.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClientesController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return _context.Clientes.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterCliente")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = _context.Clientes.AsNoTracking().FirstOrDefault(p => p.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCliente", new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Cliente> Delete(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(p => p.ClienteId == id);
            //var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return cliente;
        }
    }
}
