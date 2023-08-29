using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Services
{
    public interface IAdicionalService
    {
        #region [GET]
        Task<ResultadoExecucaoListaQuery<ListaAdicionaisEstabelecimentoQuery>> GetAdicionais(int idEstabelecimento, int idCategoria);
        #endregion [GET]

        #region [POST]
        Task<ResultadoExecucaoQuery<int>> PostAdicional(AdicionalModel adicional);
        #endregion [POST]

        #region [PUT] 
        Task<ResultadoExecucaoQuery<int>> PutAdicional(AdicionalModel adicional);
        #endregion [PUT] 

        #region [DELETE] 
        Task<ResultadoExecucaoQuery<IngredienteModel>> DeleteAdicional(int id);
        #endregion [DELETE] 
    }
}
