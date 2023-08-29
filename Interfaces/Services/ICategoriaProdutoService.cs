using ApiCardapio.Commands;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Services
{
    public interface ICategoriaProdutoService
    {
        #region [GET]
        Task<ResultadoExecucaoListaQuery<CategoriaProdutoModel>> GetCategoriasExibidasCardapio(int estabelecimentoId);
        #endregion [GET]

        #region [POST]
        Task<ResultadoExecucaoQuery<int>> PostCategoriaProduto(CategoriaProdutoCommand categoriaProduto);
        #endregion [POST]

        #region [PUT]
        Task<ResultadoExecucaoQuery<int>> PutCategoriaProduto(CategoriaProdutoCommand categoriaProduto);
        #endregion [PUT]
    }
}
