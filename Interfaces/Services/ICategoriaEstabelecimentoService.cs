using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Services
{
    public interface ICategoriaEstabelecimentoService
    {
        #region [GET]
        Task<ResultadoExecucaoListaQuery<CategoriaEstabelecimentoModel>> GetCategoriasEstabelecimento();
        #endregion [GET]
        #region [POST]
        Task<ResultadoExecucaoQuery<int>> PostCategoriaEstabelecimento(CategoriaEstabelecimentoModel categoriaEstabelecimento);
        #endregion [POST]

        #region [PUT]
        Task<ResultadoExecucaoQuery<int>> PutCategoriaEstabelecimento(CategoriaEstabelecimentoModel categoriaEstabelecimento);
        #endregion [PUT]
    }
}
