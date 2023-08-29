using ApiCardapio.Commands;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Services
{
    public interface ICategoriaAdicionalService
    {
        #region [POST]
        Task<ResultadoExecucaoQuery<int>> PostCategoriaAdicional(CategoriaProdutoCommand categoriaAdicional);
        #endregion [POST]

        #region [PUT]
        Task<ResultadoExecucaoQuery<int>> PutCategoriaAdicional(CategoriaAdicionalModel categoriaAdicional);
        #endregion [PUT]
    }
}
