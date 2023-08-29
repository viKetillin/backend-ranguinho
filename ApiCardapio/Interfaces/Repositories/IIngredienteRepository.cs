using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Repositories
{
    public interface IIngredienteRepository
    {
        #region [GET]
        Task<ResultadoExecucaoListaQuery<IngredienteModel>> GetIngredientes(int estabelecimentoId);
        Task<ResultadoExecucaoListaQuery<IngredienteQuery>> GetIngredientesPorProduto(int estabelecimentoId, int produtoId);
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
