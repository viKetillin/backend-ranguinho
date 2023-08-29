using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("Produto")]
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string NomeProduto { get; set; }

        #nullable enable
        [StringLength(500)]
        public string? DescricaoProduto { get; set; }

        [StringLength(500)]
        public string? ProductDescription { get; set; }        

        public ICollection<ProdutoIngredienteModel>? ProdutoIngredientes { get; set; }

        [MaxLength]
        public string? ImagemProduto { get; set; }
        #nullable disable

        [ForeignKey("CategoriaId")]
        public CategoriaProdutoModel CategoriaProduto { get; set; }
        public int CategoriaProdutoId { get; set; }
    }
}
