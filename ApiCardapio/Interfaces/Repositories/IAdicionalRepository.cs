using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Threading.Tasks;

namespace ApiCardapio.Interfaces.Repositories
{
    public interface IAdicionalRepository
    {
        Task<ResultadoExecucaoListaQuery<ListaAdicionaisEstabelecimentoQuery>> GetAdicionais(int idEstabelecimento, int idCategoria);
        Task<ResultadoExecucaoQuery<int>> PostAdicional(AdicionalModel adicional);
        Task<ResultadoExecucaoQuery<int>> PutAdicional(AdicionalModel adicionalModel);
        Task<ResultadoExecucaoQuery<IngredienteModel>> DeleteAdicional(int id);
    }
}
