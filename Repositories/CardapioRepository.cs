using ApiCardapio.Data;
using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCardapio.Repositories
{
    public class CardapioRepository : AbstractRepository, ICardapioRepository
    {
        private readonly Contexto _context;
        private readonly IDbContext _dbContext;

        public CardapioRepository(IDbContext dbContext, Contexto context) : base(dbContext)
        {
            _context = context;
            _dbContext = dbContext;
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<ListaProdutosEstabelecimentoQuery>> GetCardapio(int idEstabelecimento, int idCategoria)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT P.ID ");
            sql.AppendLine("       ,P.IMAGEMPRODUTO ");
            sql.AppendLine("       ,P.NOMEPRODUTO ");
            sql.AppendLine("       ,P.DESCRICAOPRODUTO ");
            sql.AppendLine("       ,P.PRODUCTDESCRIPTION ");
            sql.AppendLine("       ,PE.ATIVO ");
            sql.AppendLine("       ,PE.VALOR ");
            sql.AppendLine("       ,PE.VALORPROMOCIONAL ");
            sql.AppendLine("       ,CP.EXIBIRCARDAPIO ");
            sql.AppendLine("   FROM PRODUTOESTABELECIMENTO PE ");
            sql.AppendLine("     INNER JOIN PRODUTO P ON (P.ID = PE.PRODUTOID) ");
            sql.AppendLine("     INNER JOIN CATEGORIAPRODUTO CP ON (CP.ID = P.CATEGORIAPRODUTOID) ");
            sql.AppendLine("     WHERE CP.ID = @IDCATEGORIA AND PE.ESTABELECIMENTOID = @IDESTABELECIMENTO");

            var resultado = ExecuteQuery<ListaProdutosEstabelecimentoQuery>(sql.ToString(), new
            {
                IDESTABELECIMENTO = idEstabelecimento,
                IDCATEGORIA = idCategoria
            }).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<ListaProdutosEstabelecimentoQuery>(resultado));
        }

        public async Task<ResultadoExecucaoQuery<ProdutoQuery>> GetProduto(int idEstabelecimento, int idProduto)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT P.ID ");
            sql.AppendLine("       ,P.IMAGEMPRODUTO ");
            sql.AppendLine("       ,P.NOMEPRODUTO ");
            sql.AppendLine("       ,P.DESCRICAOPRODUTO ");
            sql.AppendLine("       ,P.PRODUCTDESCRIPTION ");
            sql.AppendLine("       ,PE.ATIVO ");
            sql.AppendLine("       ,PE.VALOR ");
            sql.AppendLine("       ,PE.VALORPROMOCIONAL ");
            sql.AppendLine("   FROM PRODUTOESTABELECIMENTO PE ");
            sql.AppendLine("     INNER JOIN PRODUTO P ON (P.ID = PE.PRODUTOID) ");
            sql.AppendLine("     WHERE PE.ESTABELECIMENTOID = @IDESTABELECIMENTO AND P.ID = @IDPRODUTO");

            var resultado = ExecuteQuery<ProdutoQuery>(sql.ToString(), new
            {
                IDESTABELECIMENTO = idEstabelecimento,
                IDPRODUTO = idProduto
            }).FirstOrDefault();

            return await Task.FromResult(new ResultadoExecucaoQuery<ProdutoQuery>(resultado));
        }

        #endregion [GET]

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostProduto([FromBody] ProdutoCommand produtoCommand)
        {
            ProdutoModel produto = new()
            {
                ImagemProduto = produtoCommand.LinkImagemProduto,
                NomeProduto = produtoCommand.NomeProduto,
                DescricaoProduto = produtoCommand.DescricaoProduto,
                ProductDescription = produtoCommand.ProductDescription,
                CategoriaProdutoId = produtoCommand.CategoriaId
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            ProdutoEstabelecimentoModel produtoEstabelecimento = new()
            {
                EstabelecimentoId = produtoCommand.EstabelecimentoId,
                Valor = produtoCommand.ValorProduto,
                ProdutoId = produto.Id,
                Ativo = produtoCommand.Ativo,
                ValorPromocional = produtoCommand.ValorPromocional
            };

            _context.ProdutoEstabelecimentos.Add(produtoEstabelecimento);
            _context.SaveChanges();

            foreach (var ingrediente in produtoCommand.Ingredientes)
            {
                AdicionalModel estabelecimentoIngredienteCategoriaModel = new()
                {
                    IngredienteId = ingrediente.Id,
                    CategoriaAdicionalId = produtoCommand.CategoriaId
                };

                _context.Adicionais.Add(estabelecimentoIngredienteCategoriaModel);
                _context.SaveChanges();

                ProdutoIngredienteModel produtoIngredienteModel = new()
                {
                    IngredienteId = ingrediente.Id,
                    ProdutoId = produto.Id,
                    Quantidade = ingrediente.Quantidade,
                };

                _context.ProdutoIngredientes.Add(produtoIngredienteModel);
                _context.SaveChanges();
            };

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso,
                Data = produto.Id
            });
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutProduto([FromForm] ProdutoCommand produtoCommand)
        {           
            ProdutoModel produto = new()
            {
                Id = produtoCommand.Id,
                ImagemProduto = produtoCommand.LinkImagemProduto,
                NomeProduto = produtoCommand.NomeProduto,
                DescricaoProduto = produtoCommand.DescricaoProduto,
                ProductDescription = produtoCommand.ProductDescription,
                CategoriaProdutoId = produtoCommand.CategoriaId
            };

            _context.Produtos.Update(produto);
            _context.SaveChanges();

            var produtoEstabelecimento = new ProdutoEstabelecimentoModel
            {
                Id = produto.Id,
                EstabelecimentoId = produtoCommand.EstabelecimentoId,
                Valor = produtoCommand.ValorProduto,
                ProdutoId = produtoCommand.Id,
                Ativo = produtoCommand.Ativo,
                ValorPromocional = produtoCommand.ValorPromocional
            };

            _context.ProdutoEstabelecimentos.Update(produtoEstabelecimento);
            _context.ProdutoIngredientes.RemoveRange(_context.ProdutoIngredientes.Where(x => x.ProdutoId == produtoCommand.Id));
            _context.SaveChanges();

            foreach (var ingrediente in produtoCommand.Ingredientes)
            {
                ProdutoIngredienteModel produtoIngredienteModel = new()
                {
                    IngredienteId = ingrediente.Id,
                    ProdutoId = produtoCommand.Id,
                    Quantidade = ingrediente.Quantidade,
                };

                _context.ProdutoIngredientes.Add(produtoIngredienteModel);
                _context.SaveChanges();
            };

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso
            });
        }
        #endregion [PUT]

        #region [DELETE]
        public async Task<ResultadoExecucaoQuery<ProdutoModel>> DeleteProduto(int id)
        {
            ProdutoModel produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return new ResultadoExecucaoQuery<ProdutoModel>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Produto não encontrado!"
                };
            }
            else
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();

                return new ResultadoExecucaoQuery<ProdutoModel>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso,
                    Mensagem = "Produto deletado com sucesso!"
                };
            }
        }
        #endregion [DELETE]
    }
}
