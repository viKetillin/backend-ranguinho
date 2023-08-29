using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("PerfilUsuario")]
    public class PerfilUsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UsuarioId")]
        public UsuarioModel Usuario { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("PerfilId")]
        public PerfilModel Perfil { get; set; }
        public int PerfilId { get; set; }
    }
}
