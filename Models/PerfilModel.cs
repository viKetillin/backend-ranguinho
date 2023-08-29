using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCardapio.Models
{
    [Table("Perfil")]
    public class PerfilModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string NomePerfil { get; set; }
    }
}
