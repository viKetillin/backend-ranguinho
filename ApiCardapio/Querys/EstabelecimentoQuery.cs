using System.Collections.Generic;

namespace ApiCardapio.Querys
{
    public class EstabelecimentoQuery
    {
        public int IdCategoriaEstabelecimento { get; set; }
        public string NomeCategoriaEstabelecimento { get; set; }

        #nullable enable
        public string? Icone { get; set; }
        #nullable disable

        public List<ListaEstabelecimentosQuery> LstEstabelecimentos { get; set; }
    }
}
