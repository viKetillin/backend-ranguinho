using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Services
{
    public class CategoriaEstabelecimentoService : ICategoriaEstabelecimentoService
    {
        private readonly ICategoriaEstabelecimentoRepository _categoriaEstabelecimentoRepository;

        public CategoriaEstabelecimentoService(ICategoriaEstabelecimentoRepository categoriaEstabelecimentoRepository)
        {
            _categoriaEstabelecimentoRepository = categoriaEstabelecimentoRepository;
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<CategoriaEstabelecimentoModel>> GetCategoriasEstabelecimento()
        {
            return await _categoriaEstabelecimentoRepository.GetCategoriasEstabelecimento();
        }
        #endregion [GET]        

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostCategoriaEstabelecimento(CategoriaEstabelecimentoModel categoriaEstabelecimento)
        {
            return await _categoriaEstabelecimentoRepository.PostCategoriaEstabelecimento(categoriaEstabelecimento);
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutCategoriaEstabelecimento(CategoriaEstabelecimentoModel categoriaEstabelecimento)
        {
            return await _categoriaEstabelecimentoRepository.PutCategoriaEstabelecimento(categoriaEstabelecimento);
        }
        #endregion [PUT]
    }
}
