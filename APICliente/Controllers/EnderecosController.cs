using APICliente.Context;
using APICliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APICliente.Controllers
{
    public class EnderecosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EnderecosController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Endereco>> Get()
        {
            return _context.Enderecos.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterEndereco")]
        public ActionResult<Endereco> Get(int id)
        {
            var endereco = _context.Enderecos.AsNoTracking().FirstOrDefault(p => p.EnderecoId == id);
            if (endereco == null)
            {
                return NotFound();
            }
            return endereco;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterEndereco", new { id = endereco.EnderecoId }, endereco);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Endereco endereco)
        {
            if (id != endereco.EnderecoId)
            {
                return BadRequest();
            }

            _context.Entry(endereco).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Endereco> Delete(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(p => p.EnderecoId == id);
            //var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
            {
                return NotFound();
            }
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return endereco;
        }
    }
}
