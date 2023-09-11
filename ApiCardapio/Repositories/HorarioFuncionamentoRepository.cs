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
    public class HorarioFuncionamentoRepository : AbstractRepository, IHorarioFuncionamentoRepository
    {
        private readonly Contexto _context;
        public HorarioFuncionamentoRepository(IDbContext dbContext, Contexto context) : base(dbContext)
        {
            _context = context;
        }

        public async Task<ResultadoExecucaoListaQuery<DiaHorasFuncionamentoModel>> GetHorarioFuncionamentoPorEstabelecimento(string linkCardapio)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SET LANGUAGE 'Brazilian' ");
            sql.AppendLine(" SELECT DHF.ID ");
            sql.AppendLine("       ,DHF.DIAINICIO ");
            sql.AppendLine("       ,DHF.DIAFIM ");
            sql.AppendLine("       ,DHF.HORAINICIO ");
            sql.AppendLine(" 	   ,DHF.HORAFIM ");
            sql.AppendLine("    FROM DIAHORASFUNCIONAMENTO DHF");
            sql.AppendLine("    INNER JOIN ESTABELECIMENTO E ON E.ID = DHF.ESTABELECIMENTOID ");
            sql.AppendLine("  WHERE LINKCARDAPIO = @LINKCARDAPIO ");

            var resultado = ExecuteQuery<DiaHorasFuncionamentoModel>(sql.ToString(), new { LINKCARDAPIO = linkCardapio }).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<DiaHorasFuncionamentoModel>(resultado));

        }
        public async Task<ResultadoExecucaoListaQuery<DiaHorarioFuncionamentoQuery>> GetHorarioFuncionamento(int estabelecimentoId)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SET LANGUAGE 'Brazilian' ");
            sql.AppendLine(" SELECT ID ");
            sql.AppendLine("       ,DATENAME(WEEKDAY, DIAINICIO) AS DIAINICIO ");
            sql.AppendLine("       ,DATENAME(WEEKDAY, DIAFIM) AS DIAFIM ");
            sql.AppendLine("       ,FORMAT(HORAINICIO, 'HH:mm') AS HORAINICIO ");
            sql.AppendLine(" 	   ,FORMAT(HORAFIM, 'HH:mm') AS HORAFIM ");
            sql.AppendLine("    FROM DIAHORASFUNCIONAMENTO ");
            sql.AppendLine("  WHERE ESTABELECIMENTOID = @ESTABELECIMENTOID ");

            var resultado = ExecuteQuery<DiaHorarioFuncionamentoQuery>(sql.ToString(), new { ESTABELECIMENTOID = estabelecimentoId }).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<DiaHorarioFuncionamentoQuery>(resultado));
        }

        public async Task<ResultadoExecucaoQuery<int>> DeleteHorarioFuncionamento(int id)
        {
            DiaHorasFuncionamentoModel horarioFuncionamento = await _context.DiasHorasFuncionamento.FindAsync(id);
            _context.DiasHorasFuncionamento.Remove(horarioFuncionamento);
            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso
            });
        }
    }
}
