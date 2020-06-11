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

        /// <summary>
        /// Exibe uma relação de clientes e endereços
        /// </summary>
        /// <returns>Retorna uma lista de objetos Cliente e Endereco</returns>
        [HttpGet("enderecos")]
        public ActionResult<IEnumerable<Cliente>> GetClientesEnderecos()
        {
            return _context.Clientes.AsNoTracking().ToList();
        }

        /// <summary>
        /// Exibe uma lista dos clientes
        /// </summary>
        /// <returns>Retorna uma lista de objetos Cliente</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return _context.Clientes.AsNoTracking().ToList();
        }

        /// <summary>
        /// Obtém uma Cliente pelo Id
        /// </summary>
        /// <param name="id">Código do Cliente</param>
        /// <returns>Objetos Clientes</returns>
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

        /// <summary>
        /// Inclui um  novo cliente
        /// </summary>
        /// <remarks>
        /// 
        /// Exemplo  de request: 
        /// 
        ///     POST api/clientes
        ///     {
        ///          "Nome": "Leandro",
        ///          "Cpf": "095.590.797-78",
        ///          "DataNascimento": "1984/01/07"
        ///     }
        /// </remarks>
        /// <param name="clienteId">Código do Cliente</param>
        /// <returns>O objeto cliente incluído</returns>
        /// <remarks>Retorna um objeto Cliente incluído</remarks>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCliente", new { id = cliente.ClienteId }, cliente);
        }

        /// <summary>
        /// Altera um cliente de um determinado identificador
        /// </summary>
        /// <remarks>
        /// 
        /// Exemplo  de request: 
        /// 
        ///     PUT api/clientes
        ///     {
        ///          "clienteId": 6,
        ///          "nome": "Rachel Barreto",
        ///          "cpf": "123.456.789-00",
        ///          "dataNascimento": "1985-02-08T00:00:00"
        ///     }
        /// </remarks>
        /// <param name="clienteId">Código do Cliente que deseja alterar</param>
        /// <param name="nome">Nome se deseja alterar</param>
        /// <param name="cpf">Cpf deseja alterar</param>
        /// <param name="dataNascimento">Data de nascimento se deseja alterar</param>
        /// <returns>O objeto endereco alterado</returns>
        /// <remarks>Retorna um objeto Endereco alterado</remarks>
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

        /// <summary>
        /// Apaga um cliente pelo seu identificador clienteId
        /// </summary>
        /// <param name="id">Código do cliente</param>
        /// <returns>Um objeto apagado</returns>
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
