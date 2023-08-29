using ApiCardapio.Data;
using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCardapio.Services
{
    public class IngredienteService : IIngredienteService
    {
        private readonly Contexto _context;
        private readonly IIngredienteRepository _ingredienteRepository;

        public IngredienteService(Contexto contexto, IIngredienteRepository ingredienteRepository)
        {
            _context = contexto;
            _ingredienteRepository = ingredienteRepository;
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<IngredienteModel>> GetIngredientes(int estabelecimentoId)
        {
            return await _ingredienteRepository.GetIngredientes(estabelecimentoId);
        }       
        #endregion [GET]

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostIngrediente(IngredienteModel ingrediente)
        {
            return await _ingredienteRepository.PostIngrediente(ingrediente);
        }      
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutIngrediente(IngredienteModel ingrediente)
        {
            if (!VerificarSeExisteIngrediente(ingrediente.Id))
            {
                return new ResultadoExecucaoQuery<int>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Ingrediente não encontrado!"
                };
            }
            else
                return await _ingredienteRepository.PutIngrediente(ingrediente);
        }
        #endregion [PUT]

        #region [DELETE]
        public async Task<ResultadoExecucaoQuery<IngredienteModel>> DeleteIngrediente(int id)
        {
            return await _ingredienteRepository.DeleteIngrediente(id);
        }      
        #endregion [DELETE]

        #region [Privados]
        private bool VerificarSeExisteIngrediente(int id) => _context.Ingredientes.Any(e => e.Id == id);
      
        #endregion [Privados]
    }
}
