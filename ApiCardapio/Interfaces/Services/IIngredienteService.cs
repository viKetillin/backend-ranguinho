using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Services
{
    public interface IIngredienteService
    {
        #region [GET]
        Task<ResultadoExecucaoListaQuery<IngredienteModel>> GetIngredientes(int estabelecimentoId);       
        #endregion [GET]

        #region [POST]
        Task<ResultadoExecucaoQuery<int>> PostIngrediente(IngredienteModel ingrediente);
        #endregion [POST]

        #region [PUT]
        Task<ResultadoExecucaoQuery<int>> PutIngrediente(IngredienteModel ingrediente);
        #endregion [PUT]        

        #region [DELETE]
        Task<ResultadoExecucaoQuery<IngredienteModel>> DeleteIngrediente(int id);
        #endregion [DELETE]
    }
}
