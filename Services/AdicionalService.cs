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
    public class AdicionalService : IAdicionalService
    {
        private readonly Contexto _context;
        private readonly IAdicionalRepository _adicionalRepository;

        public AdicionalService(Contexto contexto, IAdicionalRepository adicionalRepository)
        {
            _context = contexto;
            _adicionalRepository = adicionalRepository;
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<ListaAdicionaisEstabelecimentoQuery>> GetAdicionais(int idEstabelecimento, int idCategoria)
        {
            return await _adicionalRepository.GetAdicionais(idEstabelecimento, idCategoria);
        }
        #endregion [GET]

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostAdicional(AdicionalModel adicional)
        {

            return await _adicionalRepository.PostAdicional(adicional);
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutAdicional(AdicionalModel adicional)
        {
            if (!VerificarSeExisteAdicional(adicional.Id))
            {
                return new ResultadoExecucaoQuery<int>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Adicional não encontrado!"
                };
            }
            else
                return await _adicionalRepository.PutAdicional(adicional);
        }
        #endregion [PUT]

        #region [DELETE]
        public async Task<ResultadoExecucaoQuery<IngredienteModel>> DeleteAdicional(int id)
        {
            return await _adicionalRepository.DeleteAdicional(id);
        }
        #endregion [DELETE]

        #region [Privados]
        private bool VerificarSeExisteAdicional(int id) => _context.Adicionais.Any(e => e.Id == id);        
        #endregion [Privados]
    }
}
