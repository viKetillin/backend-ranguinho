using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Services
{
    public interface INavegacaoService
    {
        #region [GET]
        Task<ResultadoExecucaoListaQuery<EstabelecimentoQuery>> GetEstabelecimentos();
        Task<ResultadoExecucaoQuery<EstabelecimentoModel>> GetEstabelecimento(string link);        
        Task<ResultadoExecucaoListaQuery<CardapioQuery>> GetCardapio(int idEstabelecimento);
        Task<ResultadoExecucaoListaQuery<DiaHorarioFuncionamentoQuery>> GetHorarioFuncionamento(int idEstabelecimento);
        #endregion [GET]
    }
}
