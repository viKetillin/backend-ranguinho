using ApiCardapio.Commands;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Repositories
{
    public interface ICategoriaProdutoRepository
    {
        #region [GET]
        Task<ResultadoExecucaoListaQuery<CategoriaProdutoModel>> GetCategoriasExibidasCardapio(int estabelecimentoId);
        Task<ResultadoExecucaoListaQuery<CategoriaProdutoModel>> GetCategoriasProduto(int estabelecimentoId);
        #endregion [GET]

        #region [POST]
        Task<ResultadoExecucaoQuery<int>> PostCategoriaProduto(CategoriaProdutoCommand categoriaProduto);
        #endregion[POST]

        #region [PUT]
        Task<ResultadoExecucaoQuery<int>> PutCategoriaProduto(CategoriaProdutoCommand categoriaProduto);
        #endregion [PUT]
    }
}
