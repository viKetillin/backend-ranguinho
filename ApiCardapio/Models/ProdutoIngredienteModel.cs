using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("ProdutoIngrediente")]
    public class ProdutoIngredienteModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IngredienteId")]
        public IngredienteModel Ingrediente { get; set; }
        public int IngredienteId { get; set; }

        [ForeignKey("ProdutoId")]
        public ProdutoModel Produto { get; set; }
        public int ProdutoId { get; set; }

        public double? Quantidade { get; set; }
    }
}
