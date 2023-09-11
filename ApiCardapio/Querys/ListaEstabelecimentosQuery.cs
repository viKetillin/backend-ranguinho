using System.Collections.Generic;

namespace ApiCardapio.Querys
{
    public class ListaEstabelecimentosQuery
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string ImagemCapa { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string LinkCardapio { get; set; }
        public bool StatusEstabelecimento { get; set; }
        public List<DiaHorarioFuncionamentoQuery> HorarioFuncionamento { get; set; }
    }
}
