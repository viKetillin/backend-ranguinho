using ApiCardapio.Data;
using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Querys;
using ApiCardapio.Repositories;
using ApiCardapio.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCardapio.Services
{
    public class HorarioFuncionamentoService : IHorarioFuncionamentoService
    {        
        private readonly Contexto _context;
        private readonly IHorarioFuncionamentoRepository _horarioFuncionamentoRepository;

        public HorarioFuncionamentoService(Contexto contexto, IHorarioFuncionamentoRepository horarioFuncionamentoRepository)
        {
            _horarioFuncionamentoRepository = horarioFuncionamentoRepository;
            _context = contexto;
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<DiaHorarioFuncionamentoQuery>> GetHorarioFuncionamento(int idEstabelecimento)
        {
            var utilities = new Utility(_context);
            bool verificarSeExisteEstabelecimento = utilities.VerificarSeExisteEstabelecimento(idEstabelecimento);
            if (!verificarSeExisteEstabelecimento)
            {
                return new ResultadoExecucaoListaQuery<DiaHorarioFuncionamentoQuery>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Estabelecimento não encontrada!"
                };
            }

            return await _horarioFuncionamentoRepository.GetHorarioFuncionamento(idEstabelecimento);
        }
        #endregion [GET]

        #region [DELETE]
        public async Task<ResultadoExecucaoQuery<int>> DeleteHorarioFuncionamento(int id)
        {
            bool verificarSeExisteHorarioFuncionamento = VerificarSeExisteHorarioFuncionamento(id);
            if (!verificarSeExisteHorarioFuncionamento)
            {
                return new ResultadoExecucaoQuery<int>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Horário funcionamento não encontrado!"
                };
            }
            else
                return await _horarioFuncionamentoRepository.DeleteHorarioFuncionamento(id);
        }
        #endregion [DELETE]

        #region [Privados]                
        private bool VerificarSeExisteHorarioFuncionamento(int id) => _context.DiasHorasFuncionamento.Any(e => e.Id == id);        
        #endregion [Privados]
    }
}
