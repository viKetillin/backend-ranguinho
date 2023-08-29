using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("CategoriaAdicional")]
    public class CategoriaAdicionalModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeCategoriaAdicional { get; set; }

        #nullable enable
        [StringLength(100)]
        public string? AdditionalCategoryName { get; set; }
        #nullable disable

    }
}
