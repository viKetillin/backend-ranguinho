using ApiCardapio.Commands;
using ApiCardapio.Data;
using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCardapio.Repositories
{
    public class CategoriasProdutosRepository : AbstractRepository, ICategoriaProdutoRepository
    {
        private readonly Contexto _context;

        public CategoriasProdutosRepository(IDbContext dbContext, Contexto context) : base(dbContext)
        {
            _context = context;
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<CategoriaProdutoModel>> GetCategoriasExibidasCardapio(int estabelecimentoId)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT ID ");
            sql.AppendLine("       ,IMAGEMFILTRO ");
            sql.AppendLine("       ,NOMECATEGORIAPRODUTO ");
            sql.AppendLine("       ,CATEGORYNAME ");
            sql.AppendLine("       ,EXIBIRCARDAPIO ");
            sql.AppendLine("   FROM CATEGORIAPRODUTO ");
            sql.AppendLine("     WHERE EXIBIRCARDAPIO = 1 AND ESTABELECIMENTOID = @ESTABELECIMENTOID");

            var resultado = ExecuteQuery<CategoriaProdutoModel>(sql.ToString(), new { ESTABELECIMENTOID = estabelecimentoId }).ToList();

            if (resultado == null)
            {
                return await Task.FromResult(new ResultadoExecucaoListaQuery<CategoriaProdutoModel>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Nenhuma categoria encontrada!"
                });
            }
            else
                return await Task.FromResult(new ResultadoExecucaoListaQuery<CategoriaProdutoModel>(resultado));
        }

        public async Task<ResultadoExecucaoListaQuery<CategoriaProdutoModel>> GetCategoriasProduto(int estabelecimentoId)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT ID ");
            sql.AppendLine("       ,IMAGEMFILTRO ");
            sql.AppendLine("       ,NOMECATEGORIAPRODUTO ");
            sql.AppendLine("       ,CATEGORYNAME ");
            sql.AppendLine("       ,EXIBIRCARDAPIO ");
            sql.AppendLine("   FROM CATEGORIAPRODUTO ");
            sql.AppendLine(" WHERE ESTABELECIMENTOID = @ESTABELECIMENTOID ");

            var resultado = ExecuteQuery<CategoriaProdutoModel>(sql.ToString(), new { ESTABELECIMENTOID = estabelecimentoId }).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<CategoriaProdutoModel>(resultado));
        }
        #endregion [GET]

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostCategoriaProduto(CategoriaProdutoCommand categoria)
        {
            CategoriaProdutoModel categoriaProduto = new()
            {
                EstabelecimentoId = categoria.EstabelecimentoId,
                CategoryName = categoria.CategoryName,
                ExibirCardapio = categoria.ExibirCardapio,
                ImagemFiltro = categoria.LinkImagemFiltro,
                NomeCategoriaProduto = categoria.NomeCategoriaProduto,
                CategoriaAdicionalId = categoria.CategoriaAdicionalId
            };

            _context.CategoriaProdutos.Add(categoriaProduto);
            _context.SaveChanges();

            CategoriaAdicionalModel categoriaAdicional = new()
            {
                NomeCategoriaAdicional = "Adicional " + categoria.NomeCategoriaProduto
            };

            _context.CategoriaAdicionais.Add(categoriaAdicional);
            _context.SaveChanges();
            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso,
                Data = categoriaProduto.Id
            });
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutCategoriaProduto(CategoriaProdutoCommand categoria)
        {
            CategoriaProdutoModel categoriaProduto = new()
            {
                Id = categoria.Id,
                CategoryName = categoria.CategoryName,
                ExibirCardapio = categoria.ExibirCardapio,
                ImagemFiltro = categoria.LinkImagemFiltro,
                NomeCategoriaProduto = categoria.NomeCategoriaProduto,
                EstabelecimentoId = categoria.EstabelecimentoId,
                CategoriaAdicionalId = categoria.CategoriaAdicionalId
            };

            _context.CategoriaProdutos.Update(categoriaProduto);
            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso
            });
        }
        #endregion [PUT]
    }
}
