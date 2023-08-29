using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCardapio.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string NomeUsuario { get; set; }

        [Required]
        [StringLength(200)]
        public string EmailUsuario { get; set; }

        [StringLength(200)]
        public string CodigoUsuario { get; set; }

        [Required]
        [StringLength(200)]
        public string Senha { get; set; }

        [StringLength(200)]
        public string Endereco { get; set; }

        [StringLength(200)]
        public string Whatsapp { get; set; }
        
        [StringLength(200)]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
