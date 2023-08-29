using ApiCardapio.Commands;
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
    public class CategoriaAdicionalRepository : AbstractRepository, ICategoriaAdicionalRepository
    {
        private readonly IDbContext _dbContext;
        private readonly Contexto _context;

        public CategoriaAdicionalRepository(IDbContext dbContext, Contexto context) : base(dbContext)
        {
            _context = context;
            _dbContext = dbContext;
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<CategoriaAdicionalModel>> GetCategoriasAdicional()
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT ID ");
            sql.AppendLine("       ,NOMECATEGORIAADICIONAL ");
            sql.AppendLine("       ,ADDITIONALCATEGORYNAME ");
            sql.AppendLine("   FROM CATEGORIAADICIONAL ");

            var resultado = ExecuteQuery<CategoriaAdicionalModel>(sql.ToString()).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<CategoriaAdicionalModel>(resultado));
        }
        #endregion [GET]

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostCategoriaAdicional(CategoriaProdutoCommand categoriaModel)
        {
            CategoriaAdicionalModel categoriaAdicional = new()
            {                
                NomeCategoriaAdicional = "Adicional " + categoriaModel.NomeCategoriaProduto              
            };

            _context.CategoriaAdicionais.Add(categoriaAdicional);
            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso,
                Data = categoriaAdicional.Id
            });
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutCategoriaAdicional(CategoriaAdicionalModel categoriaModel)
        {
            CategoriaAdicionalModel categoriaAdicional = new()
            {
                Id = categoriaModel.Id,
                AdditionalCategoryName = categoriaModel.AdditionalCategoryName,                
                NomeCategoriaAdicional = categoriaModel.NomeCategoriaAdicional,
            };

            _context.CategoriaAdicionais.Update(categoriaAdicional);
            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso
            });
        }
        #endregion [PUT]
    }
}
