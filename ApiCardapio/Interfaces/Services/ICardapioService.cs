using ApiCardapio.Models;
using ApiCardapio.Querys;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Services
{
    public interface ICardapioService
    {
        #region [GET]
        Task<ResultadoExecucaoListaQuery<CardapioQuery>> GetCardapio(int idEstabelecimento, UserFromTokenQuery usuario);
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
