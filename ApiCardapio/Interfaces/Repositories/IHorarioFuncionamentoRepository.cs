using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Repositories
{
    public interface IHorarioFuncionamentoRepository
    {
        Task<ResultadoExecucaoListaQuery<DiaHorasFuncionamentoModel>> GetHorarioFuncionamentoPorEstabelecimento(string linkCardapio);
        Task<ResultadoExecucaoListaQuery<DiaHorarioFuncionamentoQuery>> GetHorarioFuncionamento(int idEstabelecimento);
        Task<ResultadoExecucaoQuery<int>> DeleteHorarioFuncionamento(int id);
    }
}
