using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("CategoriaEstabelecimento")]
    public class CategoriaEstabelecimentoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }
    }
}
