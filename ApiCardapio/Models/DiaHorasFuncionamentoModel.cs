using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCardapio.Models
{
    [Table("DiaHorasFuncionamento")]
    public class DiaHorasFuncionamentoModel
    {        
        [Key]
        public int Id { get; set; }

        [Required]
        public DayOfWeek DiaInicio { get; set; }

        [Required]
        public DayOfWeek DiaFim { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime? HoraInicio { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime? HoraFim { get; set; }

        [ForeignKey("EstabelecimentoId")]
        public EstabelecimentoModel Estabelecimento { get; set; }

        public int EstabelecimentoId { get; set; }
       
    }
}
