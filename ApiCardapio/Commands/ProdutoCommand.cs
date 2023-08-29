using ApiCardapio.Models;
using ApiCardapio.Querys;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ApiCardapio
{
    public class ProdutoCommand
    {
        public int Id { get; set; }
        #nullable enable
        public string? LinkCardapio { get; set; }
        public string? LinkImagemProduto { get; set; }
        public IFormFile? ImagemProduto { get; set; }
        #nullable disable
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string ProductDescription { get; set; }
        public int CategoriaId { get; set; }
        public int EstabelecimentoId { get; set; }
        public List<RelacaoIngredienteQuery> Ingredientes { get; set; }
        public double ValorProduto { get; set; }
        public double ValorPromocional { get; set; }
        public bool Ativo  { get; set; }

    }
}
