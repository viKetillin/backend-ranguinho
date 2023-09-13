using ApiCardapio.Data;
using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using ApiCardapio.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCardapio.Services
{
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly Contexto _context;
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public EstabelecimentoService(Contexto contexto, IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
            _context = contexto;
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<EstabelecimentoModel>> GetEstabelecimentos(UserFromTokenQuery usuario)
        {
            return await _estabelecimentoRepository.GetEstabelecimentos(usuario);
        }

        public async Task<ResultadoExecucaoQuery<EstabelecimentoModel>> GetEstabelecimento(string link)
        {
            return await _estabelecimentoRepository.GetEstabelecimento(link);
        }
        #endregion [GET]

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostEstabelecimento(EstabelecimentoCommand estabelecimentoCommand, UserFromTokenQuery usuario)
        {
            if (VerificarSeExisteLinkCadastrado(estabelecimentoCommand.LinkCardapio))
            {
                return new ResultadoExecucaoQuery<int>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Já existe um estabelecimento com o link " + estabelecimentoCommand.LinkCardapio + "!"
                };
            }
            else
                return await _estabelecimentoRepository.PostEstabelecimento(estabelecimentoCommand, usuario);
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutEstabelecimento(EstabelecimentoCommand estabelecimentoCommand)
        {
            var utilities = new Utility(_context);

            bool verificarSeExisteEstabelecimento = utilities.VerificarSeExisteEstabelecimento(estabelecimentoCommand.Id);
            if (!verificarSeExisteEstabelecimento)
            {
                return new ResultadoExecucaoQuery<int>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Estabelecimento não encontrado!"
                };
            }
            else
                return await _estabelecimentoRepository.PutEstabelecimento(estabelecimentoCommand);
        }
        #endregion [PUT]

        #region [DELETE]
        public async Task<ResultadoExecucaoQuery<int>> DeleteEstabelecimento(int id)
        {
            var utilities = new Utility(_context);

            bool verificarSeExisteEstabelecimento = utilities.VerificarSeExisteEstabelecimento(id);
            if (!verificarSeExisteEstabelecimento)
            {
                return new ResultadoExecucaoQuery<int>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Estabelecimento não encontrada!"
                };
            }
            else
                return await _estabelecimentoRepository.DeleteEstabelecimento(id);
        }
        #endregion [DELETE]

        #region [Privados]               
        private bool VerificarSeExisteLinkCadastrado(string link) => _context.Estabelecimentos.Any(e => e.LinkCardapio == link);
        #endregion [Privados]
    }
}
