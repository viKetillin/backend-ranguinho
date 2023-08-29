using ApiCardapio.Data;
using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCardapio.Repositories
{
    public class IngredienteRepository : AbstractRepository, IIngredienteRepository
    {
        private readonly IDbContext _dbContext;
        private readonly Contexto _context;

        public IngredienteRepository(IDbContext dbContext, Contexto context) : base(dbContext)
        {
            _dbContext = dbContext;
            _context = context;
        }

        #region [GET]        
        public async Task<ResultadoExecucaoListaQuery<IngredienteModel>> GetIngredientes(int estabelecimentoId)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT ID ");
            sql.AppendLine("       ,NOMEINGREDIENTE ");
            sql.AppendLine("       ,NAMEINGREDIENT ");
            sql.AppendLine("       ,DESCRICAOINGREDIENTE ");
            sql.AppendLine("       ,ESTABELECIMENTOID ");
            sql.AppendLine("    FROM INGREDIENTE ");
            sql.AppendLine(" WHERE ESTABELECIMENTOID = @ESTABELECIMENTOID ");

            var resultado = ExecuteQuery<IngredienteModel>(sql.ToString(), new
            {
                ESTABELECIMENTOID = estabelecimentoId
            }).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<IngredienteModel>(resultado));
        }  
        
        public async Task<ResultadoExecucaoListaQuery<IngredienteQuery>> GetIngredientesPorProduto(int estabelecimentoId, int produtoId)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT I.ID ");
            sql.AppendLine("       ,I.NOMEINGREDIENTE ");
            sql.AppendLine("       ,I.NAMEINGREDIENT ");
            sql.AppendLine("       ,I.DESCRICAOINGREDIENTE ");
            sql.AppendLine("       ,I.ESTABELECIMENTOID ");
            sql.AppendLine("    FROM INGREDIENTE I");
            sql.AppendLine(" INNER JOIN PRODUTOINGREDIENTE PIN ON PIN.INGREDIENTEID = I.ID ");
            sql.AppendLine(" WHERE ESTABELECIMENTOID = @ESTABELECIMENTOID AND PIN.PRODUTOID = @PRODUTOID ");

            var resultado = ExecuteQuery<IngredienteQuery>(sql.ToString(), new
            {
                ESTABELECIMENTOID = estabelecimentoId,
                PRODUTOID = produtoId
            }).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<IngredienteQuery>(resultado));
        }
        #endregion [GET]

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostIngrediente(IngredienteModel ingredienteModel)
        {
            IngredienteModel ingrediente = new()
            {
                DescricaoIngrediente = ingredienteModel.DescricaoIngrediente,
                NameIngredient = ingredienteModel.NameIngredient,
                NomeIngrediente = ingredienteModel.NomeIngrediente,
                EstabelecimentoId = ingredienteModel.EstabelecimentoId
            };

            _context.Ingredientes.Add(ingrediente);
            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso,
                Data = ingrediente.Id
            });
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutIngrediente(IngredienteModel ingredienteModel)
        {
            IngredienteModel ingrediente = new()
            {
                Id = ingredienteModel.Id,
                DescricaoIngrediente = ingredienteModel.DescricaoIngrediente,
                NameIngredient = ingredienteModel.NameIngredient,
                NomeIngrediente = ingredienteModel.NomeIngrediente,
                EstabelecimentoId = ingredienteModel.EstabelecimentoId
            };

            _context.Ingredientes.Update(ingrediente);
            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso
            });
        }
        #endregion [PUT]

        #region [DELETE]
        public async Task<ResultadoExecucaoQuery<IngredienteModel>> DeleteIngrediente(int id)
        {
            IngredienteModel ingrediente = await _context.Ingredientes.FindAsync(id);
            bool verificarSeUsadoEmProduto = _context.ProdutoIngredientes.Any(e => e.IngredienteId == id);
            bool verificarSeUsadoEmAdicional = _context.Adicionais.Any(e => e.IngredienteId == id);

            if (verificarSeUsadoEmProduto)
            {
                return new ResultadoExecucaoQuery<IngredienteModel>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Não é possível excluir o ingrediente, pois ele está sendo usado em um produto!"
                };
            }

            if (verificarSeUsadoEmAdicional)
            {
                return new ResultadoExecucaoQuery<IngredienteModel>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Não é possível excluir o ingrediente, pois ele é o adicional de uma categoria!"
                };
            }

            if (ingrediente == null)
            {
                return new ResultadoExecucaoQuery<IngredienteModel>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Ingrediente não encontrado!"
                };
            }
            else
            {
                _context.Ingredientes.Remove(ingrediente);
                await _context.SaveChangesAsync();

                return new ResultadoExecucaoQuery<IngredienteModel>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso,
                    Mensagem = "Ingrediente deletado com sucesso!"
                };
            }
        }
        #endregion [DELETE]        
    }
}
