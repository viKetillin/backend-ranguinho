using ApiCardapio.Commands;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Services
{
    public class CategoriaAdicionalService : ICategoriaAdicionalService
    {
        private readonly ICategoriaAdicionalRepository _categoriaAdicionalRepository;

        public CategoriaAdicionalService(ICategoriaAdicionalRepository categoriaAdicionalRepository)
        {
            _categoriaAdicionalRepository = categoriaAdicionalRepository;
        }

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostCategoriaAdicional(CategoriaProdutoCommand categoriaAdicional)
        {
            return await _categoriaAdicionalRepository.PostCategoriaAdicional(categoriaAdicional);
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutCategoriaAdicional(CategoriaAdicionalModel categoriaAdicional)
        {
            return await _categoriaAdicionalRepository.PutCategoriaAdicional(categoriaAdicional);
        }
        #endregion [PUT]
    }
}
