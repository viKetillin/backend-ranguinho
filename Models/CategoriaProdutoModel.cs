using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("CategoriaProduto")]
    public class CategoriaProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeCategoriaProduto { get; set; }        
        
        [Required]        
        public bool ExibirCardapio { get; set; }

        #nullable enable
        [StringLength(100)]
        public string? CategoryName { get; set; }
        public string? ImagemFiltro { get; set; }
        #nullable disable

        [ForeignKey("CategoriaAdicionalId")]
        public CategoriaAdicionalModel CategoriaAdicional { get; set; }
        public int? CategoriaAdicionalId { get; set; }       
        
        [ForeignKey("EstabelecimentoId")]
        public EstabelecimentoModel Estabelecimento { get; set; }
        public int? EstabelecimentoId { get; set; }
    }
}
