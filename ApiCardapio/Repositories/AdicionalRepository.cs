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
    public class AdicionalRepository : AbstractRepository, IAdicionalRepository
    {
        private readonly Contexto _context;        

        public AdicionalRepository(IDbContext dbContext, Contexto context) : base(dbContext)
        {
            _context = context;            
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<ListaAdicionaisEstabelecimentoQuery>> GetAdicionais(int idEstabelecimento, int idCategoria)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT A.ID AS IDADICIONAL ");
            sql.AppendLine("       ,A.INGREDIENTEID AS IDINGREDIENTE ");
            sql.AppendLine("       ,I.NOMEINGREDIENTE AS NOMEADICIONAL ");
            sql.AppendLine("       ,A.VALOR AS VALOR ");
            sql.AppendLine("   FROM CATEGORIAPRODUTO CP ");
            sql.AppendLine("     INNER JOIN CATEGORIAADICIONAL CA ON CA.ID = CP.CATEGORIAADICIONALID  ");
            sql.AppendLine("     INNER JOIN ADICIONAL A ON A.CATEGORIAADICIONALID = CA.ID  ");
            sql.AppendLine("    INNER JOIN INGREDIENTE I ON I.ID = A.INGREDIENTEID ");
            sql.AppendLine("     WHERE CP.ID = @IDCATEGORIA AND I.ESTABELECIMENTOID = @IDESTABELECIMENTO ");

            var resultado = ExecuteQuery<ListaAdicionaisEstabelecimentoQuery>(sql.ToString(), new
            {
                IDESTABELECIMENTO = idEstabelecimento,
                IDCATEGORIA = idCategoria
            }).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<ListaAdicionaisEstabelecimentoQuery>(resultado));
        }
        #endregion [GET]

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostAdicional(AdicionalModel adicionalModel)
        {
            AdicionalModel adicional = new()
            {
                Valor = adicionalModel.Valor,
                IngredienteId = adicionalModel.IngredienteId,
                CategoriaAdicionalId = adicionalModel.CategoriaAdicionalId
            };

            _context.Adicionais.Add(adicional);
            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso,
                Data = adicional.Id
            });
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutAdicional(AdicionalModel adicionalModel)
        {
            AdicionalModel adicional = new()
            {
                Id = adicionalModel.Id,
                Valor = adicionalModel.Valor,
                IngredienteId = adicionalModel.IngredienteId,
                CategoriaAdicionalId = adicionalModel.CategoriaAdicionalId
            };

            _context.Adicionais.Update(adicional);
            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso
            });
        }
        #endregion [PUT]

        #region [DELETE]
        public async Task<ResultadoExecucaoQuery<IngredienteModel>> DeleteAdicional(int id)
        {
            AdicionalModel adicional = await _context.Adicionais.FindAsync(id);

            if (adicional == null)
            {
                return new ResultadoExecucaoQuery<IngredienteModel>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Adicional não encontrado!"
                };
            }
            else
            {
                _context.Adicionais.Remove(adicional);
                await _context.SaveChangesAsync();

                return new ResultadoExecucaoQuery<IngredienteModel>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso,
                    Mensagem = "Adicional deletado com sucesso!"
                };
            }
        }
        #endregion [DELETE]
    }
}