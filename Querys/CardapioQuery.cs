using System.Collections.Generic;

namespace ApiCardapio.Querys
{
    public class CardapioQuery
    {
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }

        #nullable enable
        public string? CategoryName { get; set; }
        public string? ImagemFiltro { get; set; }
        #nullable disable

        public List<ListaProdutosEstabelecimentoQuery> LstProdutosEstabelecimento { get; set; }
        public List<ListaAdicionaisEstabelecimentoQuery> LstAdicionaisEstabelecimentos { get; set; }
    }
}
