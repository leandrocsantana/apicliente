using APICliente.Context;
using APICliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APICliente.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EnderecosController(AppDbContext contexto)
        {
            _context = contexto;
        }

        /// <summary>
        /// Exibe uma lista dos endereços
        /// </summary>
        /// <returns>Retorna uma lista de objetos Endereco</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Endereco>> Get()
        {
            return _context.Enderecos.AsNoTracking().ToList();
        }

        /// <summary>
        /// Obtem um endereço pelo seu identificador enderecoId
        /// </summary>
        /// <param name="id">Código do endereço</param>
        /// <returns>Um objeto Endereço</returns>
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

        /// <summary>
        /// Inclui um  novo endereço
        /// </summary>
        /// <remarks>
        /// 
        /// Exemplo  de request: 
        /// 
        ///     POST api/enderecos
        ///     {
        ///          "Logradouro": "Rua Alfredo Cabussu",
        ///           "Bairro": "Pavuna",
        ///           "Cidade": "Rio de Janeiro",
        ///           "Estado": "Rio de janeiro",
        ///           "ClienteId": 4
        ///     }
        /// </remarks>
        /// <param name="enderecoId">Código do Endereco</param>
        /// <returns>O objeto endereco incluído</returns>
        /// <remarks>Retorna um objeto Endereco incluído</remarks>
        [HttpPost]
        public ActionResult Post([FromBody] Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterEndereco", new { id = endereco.EnderecoId }, endereco);
        }

        /// <summary>
        /// Altera um endereço de um determinado identificador
        /// </summary>
        /// <remarks>
        /// 
        /// Exemplo  de request: 
        /// 
        ///     PUT api/enderecos
        ///     {
        ///          "enderecoId": 4,
        ///          "Logradouro": "Rua Alfredo Cabussu",
        ///           "Bairro": "Pavuna",
        ///           "Cidade": "Rio de Janeiro",
        ///           "Estado": "Rio de janeiro",
        ///           "ClienteId": 4
        ///     }
        /// </remarks>
        /// <param name="enderecoId">Código do Endereco que deseja alterar</param>
        /// <returns>O objeto endereco alterado</returns>
        /// <remarks>Retorna um objeto Endereco alterado</remarks>
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

        /// <summary>
        /// Deleta um endereço pelo seu identificador enderecoId
        /// </summary>
        /// <param name="id">Código do endereço</param>
        /// <returns>Um objeto apagado</returns>
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
