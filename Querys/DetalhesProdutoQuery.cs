using System.Collections.Generic;

namespace ApiCardapio.Querys
{
    public class DetalhesProdutoQuery
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string ProductDescription { get; set; }
        public double ValorProduto { get; set; }
        public double? ValorPromocional { get; set; }
        public string ImagemProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int IdCategoria { get; set; }

        public List<ListaPontoCarneQuery> LstPontoCarne { get; set; }
        public List<ListaIngredientesQuery> LstIngredientes { get; set; }
        public List<ListaAdicionaisProdutoQuery> LstAdicionais { get; set; }

    }
}
