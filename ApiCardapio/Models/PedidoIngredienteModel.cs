using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("PedidoIngrediente")]
    public class PedidoIngredienteModel
    {
        [Key]
        public int Id { get; set; }

        public double Quantidade { get; set; }

        [ForeignKey("PedidoId")]
        public PedidoModel Pedido { get; set; }
        public int PedidoId { get; set; }

        [ForeignKey("IngredienteId")]
        public IngredienteModel Ingrediente { get; set; }
        public int? IngredienteId { get; set; }

        [ForeignKey("ProdutoPedidoId")]
        public ProdutoPedidoModel ProdutoPedido { get; set; }
        public int ProdutoPedidoId { get; set; }

        [ForeignKey("ProdutoId")]
        public ProdutoModel Produto { get; set; }
        public int? ProdutoId { get; set; }
    }
}
