using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("ProdutoEstabelecimento")]
    public class ProdutoEstabelecimentoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 100)]
        public double Valor { get; set; }

        [Range(1, 100)]
        public double ValorPromocional { get; set; }

        [Required]        
        public bool Ativo { get; set; }

        #nullable enable
        public string? Observacao { get; set; }
        #nullable disable

        [ForeignKey("ProdutoId")]
        public ProdutoModel Produto { get; set; }
        public int ProdutoId { get; set; }


        [ForeignKey("EstabelecimentoId")]
        public EstabelecimentoModel Estabelecimento { get; set; }

        public int EstabelecimentoId { get; set; }
    }
}
