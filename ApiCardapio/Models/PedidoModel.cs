using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("Pedido")]
    public class PedidoModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataHora { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Troco { get; set; }

        [Required]
        public bool Entrega { get; set; }

        [ForeignKey("UsuarioId")]
        public UsuarioModel Usuario { get; set; }
        public int? UsuarioId { get; set; }

        [ForeignKey("PagamentoId")]
        public PagamentoModel Pagamento { get; set; }
        public int? PagamentoId { get; set; }
    }
}
