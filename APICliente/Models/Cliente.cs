using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APICliente.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public Cliente()
        {
            Enderecos = new Collection<Endereco>();
        }
        [Key]
        public int ClienteId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<Endereco> Enderecos{ get; set; }
    }
}
