using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("Adicional")]
    public class AdicionalModel
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, 100)]
        public double? Valor { get; set; }

        [ForeignKey("IngredienteId")]
        public IngredienteModel Ingrediente { get; set; }
        public int IngredienteId { get; set; }

        [ForeignKey("CategoriaAdicionalId")]
        public CategoriaAdicionalModel CategoriaAdicional { get; set; }
        public int? CategoriaAdicionalId { get; set; }
    }
}
