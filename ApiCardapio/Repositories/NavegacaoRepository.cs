using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCardapio.Repositories
{
    public class NavegacaoRepository : AbstractRepository, INavegacaoRepository
    {
        public NavegacaoRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        #region [GET]

        public async Task<ResultadoExecucaoListaQuery<EstabelecimentoModel>> GetEstabelecimentos()
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT ID ");
            sql.AppendLine("       ,UF ");
            sql.AppendLine("       ,CIDADE ");
            sql.AppendLine("       ,ENDERECO ");
            sql.AppendLine("       ,TELEFONE ");
            sql.AppendLine("       ,LINKCARDAPIO ");
            sql.AppendLine("    FROM ESTABELECIMENTO ");

            var resultado = ExecuteQuery<EstabelecimentoModel>(sql.ToString()).ToList();

            if (resultado == null)
            {
                return await Task.FromResult(new ResultadoExecucaoListaQuery<EstabelecimentoModel>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Nenhum estabelecimento encontrado!"
                });
            }
            else
                return await Task.FromResult(new ResultadoExecucaoListaQuery<EstabelecimentoModel>(resultado));
        }

        public async Task<ResultadoExecucaoQuery<EstabelecimentoModel>> GetEstabelecimento(string link)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT ID ");
            sql.AppendLine("       ,UF ");
            sql.AppendLine("       ,ENDERECO ");
            sql.AppendLine("       ,TELEFONE ");
            sql.AppendLine("       ,CIDADE ");
            sql.AppendLine("       ,LINKCARDAPIO ");
            sql.AppendLine("       ,LOGO ");
            sql.AppendLine("       ,IMAGEMCAPA ");
            sql.AppendLine("    FROM ESTABELECIMENTO ");
            sql.AppendLine("  WHERE LINKCARDAPIO = @LINK ");

            var resultado = ExecuteQuery<EstabelecimentoModel>(sql.ToString(), new { LINK = link }).SingleOrDefault();

            if (resultado == null)
            {
                return await Task.FromResult(new ResultadoExecucaoQuery<EstabelecimentoModel>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Estabelecimento não encontrado!"
                });
            }
            else
                return await Task.FromResult(new ResultadoExecucaoQuery<EstabelecimentoModel>(resultado));
        }
        #endregion [GET]
    }
}
