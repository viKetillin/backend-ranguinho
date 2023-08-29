using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCardapio.Models
{
    [Table("Pagamento")]
    public class PagamentoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string NomeFormaPagamento { get; set; }
    }
}
