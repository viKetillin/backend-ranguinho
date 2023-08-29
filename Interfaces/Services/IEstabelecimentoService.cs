using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Services
{
    public interface IEstabelecimentoService
    {
        #region [GET]
        Task<ResultadoExecucaoListaQuery<EstabelecimentoModel>> GetEstabelecimentos(UserFromTokenQuery usuario);
        Task<ResultadoExecucaoQuery<EstabelecimentoModel>> GetEstabelecimento(string link);
        #endregion [GET]

        #region [POST]
        Task<ResultadoExecucaoQuery<int>> PostEstabelecimento(EstabelecimentoCommand estabelecimentoCommand, UserFromTokenQuery usuario);
        #endregion [POST]

        #region [PUT]
        Task<ResultadoExecucaoQuery<int>> PutEstabelecimento(EstabelecimentoCommand estabelecimentoCommand);
        #endregion [PUT]

        #region [DELETE]
        Task<ResultadoExecucaoQuery<int>> DeleteEstabelecimento(int id);
        #endregion [DELETE]
    }
}
