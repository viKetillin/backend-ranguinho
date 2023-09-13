using ApiCardapio.Data;
using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCardapio.Repositories
{
    public class EstabelecimentoRepository : AbstractRepository, IEstabelecimentoRepository
    {
        private readonly Contexto _context;
        public EstabelecimentoRepository(IDbContext dbContext, Contexto context) : base(dbContext)
        {
            _context = context;
        }

        #region [GET]
        public async Task<ResultadoExecucaoListaQuery<EstabelecimentoModel>> GetEstabelecimentosPorCategoria(int categoriaId)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT ID ");
            sql.AppendLine("       ,UF ");
            sql.AppendLine("       ,CIDADE ");
            sql.AppendLine("       ,ENDERECO ");
            sql.AppendLine("       ,TELEFONE ");
            sql.AppendLine("       ,LINKCARDAPIO ");
            sql.AppendLine("       ,WHATSAPP ");
            sql.AppendLine("       ,INSTAGRAM ");
            sql.AppendLine("       ,FACEBOOK ");
            sql.AppendLine("       ,LOGO ");
            sql.AppendLine("       ,NOME ");
            sql.AppendLine("       ,LINKCARDAPIO ");
            sql.AppendLine("       ,IMAGEMCAPA ");
            sql.AppendLine("    FROM ESTABELECIMENTO ");
            sql.AppendLine(" WHERE CATEGORIAESTABELECIMENTOID = @CATEGORIAID ");

            var resultado = ExecuteQuery<EstabelecimentoModel>(sql.ToString(), new { CATEGORIAID = categoriaId }).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<EstabelecimentoModel>(resultado));
        }

        public async Task<ResultadoExecucaoListaQuery<EstabelecimentoModel>> GetEstabelecimentos(UserFromTokenQuery usuario)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT E.ID ");
            sql.AppendLine("       ,E.UF ");
            sql.AppendLine("       ,E.CIDADE ");
            sql.AppendLine("       ,E.ENDERECO ");
            sql.AppendLine("       ,E.TELEFONE ");
            sql.AppendLine("       ,E.LINKCARDAPIO ");
            sql.AppendLine("       ,E.WHATSAPP ");
            sql.AppendLine("       ,E.INSTAGRAM ");
            sql.AppendLine("       ,E.FACEBOOK ");
            sql.AppendLine("       ,E.LOGO ");
            sql.AppendLine("       ,E.NOME ");
            sql.AppendLine("       ,E.IMAGEMCAPA ");
            sql.AppendLine("    FROM ESTABELECIMENTO E");
            if (usuario.Perfil == "Proprietário")
            {
                UsuarioModel usuarioId = await _context.Usuarios.FirstOrDefaultAsync(u => u.CodigoUsuario == usuario.CodigoUsuario);
                sql.AppendLine(" INNER JOIN USUARIOESTABELECIMENTO UE ON E.ID = UE.ESTABELECIMENTOID");
                sql.AppendLine(" WHERE USUARIOID = " + usuarioId.Id);
            }

            var resultado = ExecuteQuery<EstabelecimentoModel>(sql.ToString()).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<EstabelecimentoModel>(resultado));
        }

        public async Task<ResultadoExecucaoQuery<EstabelecimentoModel>> GetEstabelecimento(string link)
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT ID ");
            sql.AppendLine("       ,UF ");
            sql.AppendLine("       ,CIDADE ");
            sql.AppendLine("       ,ENDERECO ");
            sql.AppendLine("       ,TELEFONE ");
            sql.AppendLine("       ,LINKCARDAPIO ");
            sql.AppendLine("       ,WHATSAPP ");
            sql.AppendLine("       ,INSTAGRAM ");
            sql.AppendLine("       ,FACEBOOK ");
            sql.AppendLine("       ,LOGO ");
            sql.AppendLine("       ,NOME ");
            sql.AppendLine("       ,IMAGEMCAPA ");
            sql.AppendLine("    FROM ESTABELECIMENTO ");
            sql.AppendLine("   WHERE LINKCARDAPIO = @LINK ");

            var resultado = ExecuteQuery<EstabelecimentoModel>(sql.ToString(), new { LINK = link }).SingleOrDefault();

            return await Task.FromResult(new ResultadoExecucaoQuery<EstabelecimentoModel>(resultado));
        }
        #endregion [GET]

        #region [POST]
        public async Task<ResultadoExecucaoQuery<int>> PostEstabelecimento(EstabelecimentoCommand estabelecimentoCommand, UserFromTokenQuery usuario)
        {            
            EstabelecimentoModel estabelecimento = new()
            {
                Nome = estabelecimentoCommand.Nome,
                Cidade = estabelecimentoCommand.Cidade,
                Endereco = estabelecimentoCommand.Endereco,
                Facebook = estabelecimentoCommand.Facebook,
                Instagram = estabelecimentoCommand.Instagram,
                LinkCardapio = estabelecimentoCommand.LinkCardapio,
                Logo = estabelecimentoCommand.LinkLogo,
                Telefone = estabelecimentoCommand.Telefone,
                UF = estabelecimentoCommand.UF,
                Whatsapp = estabelecimentoCommand.Whatsapp,
                CategoriaEstabelecimentoId = estabelecimentoCommand.CategoriaEstabelecimentoId,
                ImagemCapa = estabelecimentoCommand.ImagemCapa
            };

            _context.Estabelecimentos.Add(estabelecimento);
            _context.SaveChanges();

            if (usuario.Perfil == "Proprietário")
            {
                UsuarioModel usuarioId = await _context.Usuarios.Where(u => u.CodigoUsuario == usuario.CodigoUsuario).FirstOrDefaultAsync();

                UsuarioEstabelecimentoModel usuarioEstabelecimento = new()
                {
                    EstabelecimentoId = estabelecimento.Id,
                    UsuarioId = usuarioId.Id
                };

                _context.UsuarioEstabelecimento.Add(usuarioEstabelecimento);                
            }

            foreach (var horario in estabelecimentoCommand.HorarioFuncionamento)
            {
                DayOfWeek diaInicio = ObterDiaDaSemana(horario.DiaInicio);
                DayOfWeek diaFim = ObterDiaDaSemana(horario.DiaFim);

                DiaHorasFuncionamentoModel horarioFuncionamento = new()
                {
                    DiaInicio = diaInicio,
                    DiaFim = diaFim,                    
                    HoraInicio = DateTime.ParseExact(horario.HoraInicio, "HH:mm", CultureInfo.InvariantCulture),
                    HoraFim = DateTime.ParseExact(horario.HoraFim, "HH:mm", CultureInfo.InvariantCulture),
                    EstabelecimentoId = estabelecimento.Id
                };

                _context.DiasHorasFuncionamento.Add(horarioFuncionamento);
            };

            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso,
                Data = estabelecimento.Id
            });
        }
        #endregion [POST]

        #region [PUT]
        public async Task<ResultadoExecucaoQuery<int>> PutEstabelecimento(EstabelecimentoCommand estabelecimentoCommand)
        {         
            EstabelecimentoModel estabelecimento = new()
            {
                Nome = estabelecimentoCommand.Nome,
                Cidade = estabelecimentoCommand.Cidade,
                Endereco = estabelecimentoCommand.Endereco,
                Facebook = estabelecimentoCommand.Facebook,
                Instagram = estabelecimentoCommand.Instagram,
                LinkCardapio = estabelecimentoCommand.LinkCardapio,
                Logo = estabelecimentoCommand.LinkLogo,
                Telefone = estabelecimentoCommand.Telefone,
                UF = estabelecimentoCommand.UF,
                Id = estabelecimentoCommand.Id,
                Whatsapp = estabelecimentoCommand.Whatsapp,
                CategoriaEstabelecimentoId = estabelecimentoCommand.CategoriaEstabelecimentoId,
                ImagemCapa = estabelecimentoCommand.ImagemCapa
            };

            _context.Estabelecimentos.Update(estabelecimento);

            foreach (var horario in estabelecimentoCommand.HorarioFuncionamento)
            {
                DayOfWeek diaInicio = ObterDiaDaSemana(horario.DiaInicio);
                DayOfWeek diaFim = ObterDiaDaSemana(horario.DiaFim);

                DiaHorasFuncionamentoModel horarioFuncionamento = new()
                {
                    Id = horario.Id,                    
                    DiaInicio = diaInicio,
                    DiaFim = diaFim,
                    HoraInicio = DateTime.ParseExact(horario.HoraInicio, "HH:mm", CultureInfo.InvariantCulture),
                    HoraFim = DateTime.ParseExact(horario.HoraFim, "HH:mm", CultureInfo.InvariantCulture),
                    EstabelecimentoId = estabelecimentoCommand.Id
                };

                _context.DiasHorasFuncionamento.Update(horarioFuncionamento);
            };

            await _context.SaveChangesAsync();
            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso
            });
        }
        #endregion [PUT]

        #region [DELETE]        
        public async Task<ResultadoExecucaoQuery<int>> DeleteEstabelecimento(int id)
        {
            EstabelecimentoModel estabelecimento = await _context.Estabelecimentos.FindAsync(id);
            _context.Estabelecimentos.Remove(estabelecimento);

            _context.DiasHorasFuncionamento.RemoveRange(_context.DiasHorasFuncionamento.Where(x => x.EstabelecimentoId == id));
            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso
            });
        }
        #endregion [DELETE]       

        public static DayOfWeek ObterDiaDaSemana(string diaSemana)
        {
            CultureInfo cultura = new("pt-BR");

            for (DayOfWeek dia = DayOfWeek.Sunday; dia <= DayOfWeek.Saturday; dia++)
            {
                string nomeDia = cultura.DateTimeFormat.GetDayName(dia);
                if (string.Equals(nomeDia, diaSemana, StringComparison.OrdinalIgnoreCase))
                {
                    //Compatibilizando com o SQL
                    return (DayOfWeek)(((int)dia + 6) % 7);
                }
            }

            throw new ArgumentException("Dia da semana inválido.");
        }
    }
}

