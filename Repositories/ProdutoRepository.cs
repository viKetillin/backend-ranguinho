using ApiCardapio.Data;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCardapio.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Contexto _context;

        public ProdutoRepository(Contexto context)
        {
            _context = context;
        }

        /*
        public async Task<IEnumerable<DetalhesProdutoQuery>> RecuperarProduto(int idEstabelecimento, int idProduto)
        {
            var listaProdutos = await _context.DetalhesProdutoQuery.FromSqlRaw("SELECT P.ID AS IDPRODUTO " +
                                                        "                             ,P.NOMEPRODUTO" +
                                                        "                             ,P.PRODUCTDESCRIPTION" +
                                                        "                             ,PF.VALOR AS VALORPRODUTO" +
                                                        "                             ,PF.VALORPROMOCIONAL" +
                                                        "                             ,P.IMAGEMPRODUTO" +
                                                        "                             ,P.DESCRICAOPRODUTO" +
                                                        "                             ,P.CATEGORIAID AS IDCATEGORIA" +
                                                        "           FROM PRODUTO P" +
                                                        "           INNER JOIN PRODUTOESTABELECIMENTO PF ON(PF.PRODUTOID = P.ID)" +
                                                        "           INNER JOIN CATEGORIAPRODUTO C ON(C.ID = P.CATEGORIAID)" +
                                                        "         WHERE PF.ESTABELECIMENTOID = " + idEstabelecimento + " AND P.ID = " + idProduto).ToListAsync();

            return listaProdutos;
        }
        
        public async Task<IEnumerable<ListaIngredientesQuery>> RecuperarIngredientesDoProduto(int idProduto)
        {
            return await _context.ListaIngredientesQuery.FromSqlRaw("SELECT I.ID AS IDINGREDIENTE" +
                                                              "            ,I.NOMEINGREDIENTE" +
                                                              "    FROM INGREDIENTE I" +
                                                              "    INNER JOIN PRODUTOINGREDIENTE PIN ON(PIN.INGREDIENTEID = I.ID)" +
                                                              "    INNER JOIN PRODUTO P ON(P.ID = PIN.PRODUTOID)" +
                                                              "  WHERE P.ID = " + idProduto ).ToListAsync();
        }   
        
        public async Task<IEnumerable<ListaAdicionaisProdutoQuery>> RecuperarAdicionaisDoProduto(int idCategoria, int idEstabelecimento)
        {
            return await _context.ListaAdicionaisProdutoQuery.FromSqlRaw("SELECT I.ID AS IDADICIONAL" +
                                                                  "      ,I.NOMEINGREDIENTE AS NOMEADICIONAL" +                                                                  
                                                                  "      ,FIC.VALOR" +
                                                                  "    FROM INGREDIENTE I" +
                                                                  "    INNER JOIN ADICIONAL AON(FIC.INGREDIENTEID = I.ID)" +
                                                                  "    INNER JOIN ESTABELECIMENTO F ON (F.ID = FIC.ESTABELECIMENTOID)" +                                                                  
                                                                  "    WHERE CATEGORIAID = " + idCategoria + " AND ESTABELECIMENTOID = " + idEstabelecimento).ToListAsync();
        }*/
    }
}
