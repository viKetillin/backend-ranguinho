using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Repositories
{
    public interface INavegacaoRepository
    {
        #region [GET]
        Task<ResultadoExecucaoQuery<EstabelecimentoModel>> GetEstabelecimento(string link);                
        #endregion [GET]
    }
}
