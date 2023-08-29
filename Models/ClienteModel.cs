using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCardapio.Models
{
    [Table("Cliente")]
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(300)]
        public string Endereco { get; set; }

        [StringLength(60)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário informar o número do whatsapp para a realização do pedido.")]
        [StringLength(20)]
        public string Whatsapp { get; set; }
    }
}
