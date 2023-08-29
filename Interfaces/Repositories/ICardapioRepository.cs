using ApiCardapio.Models;
using ApiCardapio.Querys;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Repositories
{
    public interface ICardapioRepository
    {
        #region [GET]
        Task<ResultadoExecucaoListaQuery<ListaProdutosEstabelecimentoQuery>> GetCardapio(int idEstabelecimento, int idCategoria);
        Task<ResultadoExecucaoQuery<ProdutoQuery>> GetProduto(int idEstabelecimento, int idProduto);
        #endregion [GET]

        #region [POST]
        Task<ResultadoExecucaoQuery<int>> PostProduto([FromBody] ProdutoCommand produtoCommand);
        #endregion [POST]

        #region [PUT]
        Task<ResultadoExecucaoQuery<int>> PutProduto([FromBody] ProdutoCommand produtoCommand);
        #endregion [PUT]

        #region [DELETE]
        Task<ResultadoExecucaoQuery<ProdutoModel>> DeleteProduto(int id);
        #endregion [DELETE]

    }
}
