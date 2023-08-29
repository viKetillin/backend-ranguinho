using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("UsuarioEstabelecimento")]
    public class UsuarioEstabelecimentoModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("EstabelecimentoId")]
        public EstabelecimentoModel Estabelecimento { get; set; }
        public int EstabelecimentoId { get; set; }

        [ForeignKey("UsuarioId")]
        public UsuarioModel Usuario { get; set; }
        public int UsuarioId { get; set; }
        
    }
}
