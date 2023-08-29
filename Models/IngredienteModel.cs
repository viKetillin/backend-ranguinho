using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("Ingrediente")]
    public class IngredienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeIngrediente { get; set; }

        #nullable enable
        [StringLength(100)]
        public string? NameIngredient { get; set; }        
                
        [StringLength(300)]
        public string? DescricaoIngrediente { get; set; }
        #nullable disable

        [ForeignKey("EstabelecimentoId")]
        public EstabelecimentoModel Estabelecimento { get; set; }
        public int EstabelecimentoId { get; set; }
    }
}
