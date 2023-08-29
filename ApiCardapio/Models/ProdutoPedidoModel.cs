using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("ProdutoPedido")]
    public class ProdutoPedidoModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Valor { get; set; }

        [ForeignKey("PedidoId")]
        public PedidoModel Pedido { get; set; }
        public int? PedidoId { get; set; }

        [ForeignKey("ProdutoEstabelecimentoId")]
        public ProdutoEstabelecimentoModel ProdutoEstabelecimento { get; set; }
        public int? ProdutoEstabelecimentoId { get; set; }

        [ForeignKey("PontoCarneId")]
        public PontoCarneModel PontoCarne { get; set; }
        public int? PontoCarneId { get; set; }
    }
}
