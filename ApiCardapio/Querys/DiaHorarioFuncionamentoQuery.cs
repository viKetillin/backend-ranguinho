﻿namespace ApiCardapio.Querys
{
    public class DiaHorarioFuncionamentoQuery
    {
        public int Id { get; set; }

        public string DiaInicio { get; set; }

        public string DiaFim { get; set; }

        public string HoraInicio { get; set; }

        public string HoraFim { get; set; }

        public int EstabelecimentoId { get; set; }
    }
}
