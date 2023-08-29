using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("PontoCarne")]
    public class PontoCarneModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomePontoCarne { get; set; }
    }
}
