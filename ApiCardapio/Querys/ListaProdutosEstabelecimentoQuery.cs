namespace ApiCardapio.Querys
{
    public class ListaProdutosEstabelecimentoQuery
    {
        public int Id { get; set; }        
        public string ImagemProduto { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string ProductDescription { get; set; }
        public bool? Ativo { get; set; }
        public double Valor { get; set; }
        public double? ValorPromocional { get; set; }
        public int? ProdutoEstabelecimentoId { get; set; }
    }
}
