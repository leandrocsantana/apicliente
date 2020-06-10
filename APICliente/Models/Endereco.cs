using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APICliente.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Logradouro { get; set; }
        [Required]
        [MaxLength(40)]
        public string Bairro { get; set; }
        [Required]
        [MaxLength(40)]
        public string Cidade { get; set; }
        [Required]
        [MaxLength(40)]
        public string Estado { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}
