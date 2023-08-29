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
    public class CategoriaEstabelecimentoRepository : AbstractRepository, ICategoriaEstabelecimentoRepository
    {        
        private readonly Contexto _context;

        public CategoriaEstabelecimentoRepository(IDbContext dbContext, Contexto context) : base(dbContext)
        {
            _context = context;     
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<CategoriaEstabelecimentoModel>> GetCategoriasEstabelecimento()
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT ID ");
            sql.AppendLine("       ,NOME ");
            sql.AppendLine("       ,ICONE ");
            sql.AppendLine("   FROM CATEGORIAESTABELECIMENTO ");

            var resultado = ExecuteQuery<CategoriaEstabelecimentoModel>(sql.ToString()).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<CategoriaEstabelecimentoModel>(resultado));
        }
        #endregion [GET]

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostCategoriaEstabelecimento(CategoriaEstabelecimentoModel CategoriaEstabelecimentoModel)
        {
            CategoriaEstabelecimentoModel categoriaEstabelecimento = new()
            {
                Icone = CategoriaEstabelecimentoModel.Icone,
                Nome = CategoriaEstabelecimentoModel.Nome               
            };

            _context.CategoriaEstabelecimento.Add(categoriaEstabelecimento);
            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso,
                Data = categoriaEstabelecimento.Id
            });
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutCategoriaEstabelecimento(CategoriaEstabelecimentoModel CategoriaEstabelecimentoModel)
        {
            CategoriaEstabelecimentoModel categoriaEstabelecimento = new()
            {
                Id = CategoriaEstabelecimentoModel.Id,
                Icone = CategoriaEstabelecimentoModel.Icone,
                Nome = CategoriaEstabelecimentoModel.Nome,
            };

            _context.CategoriaEstabelecimento.Update(categoriaEstabelecimento);
            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso
            });
        }
        #endregion [PUT]
    }
}
