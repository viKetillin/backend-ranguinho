using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("Estabelecimento")]
    public class EstabelecimentoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        
        [Required]
        [StringLength(2)]
        public string UF { get; set; }

        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefone { get; set; }

        #nullable enable
        [StringLength(20)]
        public string? Whatsapp { get; set; }
                
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        #nullable disable

        [Required]
        public string Logo { get; set; }    
        
        [Required]
        public string ImagemCapa { get; set; }

        [Required]        
        public string LinkCardapio { get; set; }

        [ForeignKey("CategoriaEstabelecimentoId")]
        public CategoriaEstabelecimentoModel CategoriaEstabelecimento { get; set; }
        public int CategoriaEstabelecimentoId { get; set; }
    }
}
