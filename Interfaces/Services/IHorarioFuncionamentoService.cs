using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Services
{
    public interface IHorarioFuncionamentoService
    {
        Task<ResultadoExecucaoListaQuery<DiaHorarioFuncionamentoQuery>> GetHorarioFuncionamento(int idEstabelecimento);
        Task<ResultadoExecucaoQuery<int>> DeleteHorarioFuncionamento(int id);
    }
}
