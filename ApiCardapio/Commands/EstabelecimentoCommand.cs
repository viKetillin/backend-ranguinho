using ApiCardapio.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ApiCardapio.Querys
{
    public class EstabelecimentoCommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        #nullable enable
        public string? Whatsapp { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public IFormFile? Logo { get; set; }
        #nullable disable

        public string LinkLogo { get; set; }
        public string ImagemCapa { get; set; }
        public string LinkCardapio { get; set; }
        public List<HorarioFuncionamentoQuery> HorarioFuncionamento { get; set; }
        public int CategoriaEstabelecimentoId { get; set; }
    }
}
