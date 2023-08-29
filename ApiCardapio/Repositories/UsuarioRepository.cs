using ApiCardapio.Commands;
using ApiCardapio.Data;
using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BC = BCrypt.Net.BCrypt;

namespace ApiCardapio.Repositories
{
    public class UsuarioRepository : AbstractRepository, IUsuarioRepository
    {
        private readonly IDbContext _dbContext;
        private readonly Contexto _context;

        public UsuarioRepository(IDbContext dbContext, Contexto context) : base(dbContext)
        {
            _context = context;
            _dbContext = dbContext;
        }

        public async Task<PerfilUsuarioModel> RecuperarUsuarioLogin(string username, string senha)
        {
            var user = await _context.PerfilUsuario.Include(u => u.Usuario).Include(p => p.Perfil).FirstOrDefaultAsync(u => u.Usuario.CodigoUsuario == username || u.Usuario.EmailUsuario == username);
            if (user == null || !BC.Verify(senha, user.Usuario.Senha))
                return null;
            else
                return user;
        }

        public async Task<UsuarioEstabelecimentoModel> RecuperarEstabelecimentoUsuario(string username)
        {
            var user = await _context.UsuarioEstabelecimento.Include(p => p.Usuario).Include(f => f.Estabelecimento).FirstOrDefaultAsync(u => u.Usuario.CodigoUsuario == username || u.Usuario.EmailUsuario == username);
            return user;
        }

        public async Task<PerfilUsuarioModel> RecuperarUsuario(string username)
        {
            var user = await _context.PerfilUsuario.Include(u => u.Usuario).Include(p => p.Perfil).FirstOrDefaultAsync(u => u.Usuario.CodigoUsuario == username);
            return user;
        }

        public async Task<ResultadoExecucaoListaQuery<UsuariosQuery>> GetUsuarios()
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT U.ID ");
            sql.AppendLine("       ,U.NOMEUSUARIO ");
            sql.AppendLine("       ,U.EMAILUSUARIO ");
            sql.AppendLine("       ,U.CODIGOUSUARIO ");
            sql.AppendLine("       ,U.SENHA ");
            sql.AppendLine("       ,U.ENDERECO ");
            sql.AppendLine("       ,U.WHATSAPP ");
            sql.AppendLine("       ,U.DATANASCIMENTO ");
            sql.AppendLine("       ,E.LINKCARDAPIO ");
            sql.AppendLine("       ,STUFF(( ");
            sql.AppendLine("          SELECT ',' + P.NOMEPERFIL ");
            sql.AppendLine("              FROM USUARIO US ");
            sql.AppendLine("          INNER JOIN PERFILUSUARIO PU ON PU.USUARIOID = US.ID ");
            sql.AppendLine("          INNER JOIN PERFIL P ON P.ID = PU.PERFILID ");
            sql.AppendLine("            WHERE U.CODIGOUSUARIO = US.CODIGOUSUARIO ");
            sql.AppendLine("          ORDER BY US.NOMEUSUARIO ");
            sql.AppendLine("          FOR XML PATH('') ");
            sql.AppendLine("       ), 1, 1, '') AS NOMEPERFIL ");
            sql.AppendLine("       ,UE.ESTABELECIMENTOID ");
            sql.AppendLine("       ,PF.PERFILID AS PERFILID ");
            sql.AppendLine("    FROM USUARIO U ");
            sql.AppendLine("  LEFT JOIN USUARIOESTABELECIMENTO UE ON U.ID = UE.USUARIOID ");
            sql.AppendLine("  LEFT JOIN ESTABELECIMENTO E ON E.ID = UE.ESTABELECIMENTOID ");
            sql.AppendLine("  INNER JOIN PERFILUSUARIO PF ON PF.USUARIOID = U.ID ");

            var resultado = ExecuteQuery<UsuariosQuery>(sql.ToString()).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<UsuariosQuery>(resultado));          
        }

        public async Task<ResultadoExecucaoListaQuery<PerfilModel>> GetPerfis()
        {
            StringBuilder sql = new();
            sql.AppendLine(" SELECT ID ");
            sql.AppendLine("       ,NOMEPERFIL ");
            sql.AppendLine("    FROM PERFIL");            

            var resultado = ExecuteQuery<PerfilModel>(sql.ToString()).ToList();

            return await Task.FromResult(new ResultadoExecucaoListaQuery<PerfilModel>(resultado));
        }
    
        public async Task<ResultadoExecucaoQuery<int>> PostUsuario([FromBody] UsuarioCommand usuarioCommand)
        {
            UsuarioModel usuario = new()
            {
                NomeUsuario = usuarioCommand.NomeUsuario,
                EmailUsuario = usuarioCommand.EmailUsuario,
                CodigoUsuario = usuarioCommand.CodigoUsuario,
                Senha = BC.HashPassword(usuarioCommand.Senha),
                DataNascimento = usuarioCommand.DataNascimento,
                Endereco = usuarioCommand.Endereco,
                Whatsapp = usuarioCommand.Whatsapp
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            PerfilUsuarioModel perfil = new()
            {
                PerfilId = (int)usuarioCommand.PerfilId,
                UsuarioId= usuario.Id,                
            };

            _context.PerfilUsuario.Add(perfil);
            _context.SaveChanges();

            if (usuarioCommand.EstabelecimentoId > 0)
            {
                UsuarioEstabelecimentoModel usuarioEstabelecimento = new()
                {
                    EstabelecimentoId = (int)usuarioCommand.EstabelecimentoId,
                    UsuarioId = usuario.Id
                };

                _context.UsuarioEstabelecimento.Add(usuarioEstabelecimento);
                _context.SaveChanges();
            }

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso,
                Data = usuario.Id
            });
        }

        public async Task<ResultadoExecucaoQuery<int>> PutUsuario([FromBody] UsuarioCommand usuarioCommand)
        {
            var senhaUsuario = _context.Usuarios.Where(u => u.Id.Equals(usuarioCommand.Id)).AsNoTracking().FirstOrDefault().Senha;
            UsuarioModel usuario = new()
            {
                Id = usuarioCommand.Id,
                NomeUsuario = usuarioCommand.NomeUsuario,
                EmailUsuario = usuarioCommand.EmailUsuario,
                CodigoUsuario = usuarioCommand.CodigoUsuario,
                Senha = !String.IsNullOrEmpty(usuarioCommand.Senha) ? BC.HashPassword(usuarioCommand.Senha) : senhaUsuario,
                DataNascimento = usuarioCommand.DataNascimento,
                Endereco = usuarioCommand.Endereco,
                Whatsapp = usuarioCommand.Whatsapp
            };

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            _context.PerfilUsuario.RemoveRange(_context.PerfilUsuario.Where(x => x.UsuarioId == usuarioCommand.Id));

            PerfilUsuarioModel perfil = new()
            {
                PerfilId = (int)usuarioCommand.PerfilId,
                UsuarioId = usuarioCommand.Id,
            };

            _context.PerfilUsuario.Add(perfil);
            _context.SaveChanges();

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso
            });
        }

        public async Task<ResultadoExecucaoQuery<int>> DeleteUsuario(int id)
        {
            _context.Usuarios.RemoveRange(_context.Usuarios.Where(x => x.Id == id));
            _context.PerfilUsuario.RemoveRange(_context.PerfilUsuario.Where(x => x.UsuarioId == id));
            _context.SaveChanges();

            var usuarioEstabelecimento = await _context.UsuarioEstabelecimento.FirstOrDefaultAsync(uf => uf.UsuarioId == id);
            if (usuarioEstabelecimento != null)
            {
                _context.UsuarioEstabelecimento.RemoveRange(_context.UsuarioEstabelecimento.Where(x => x.UsuarioId == id));
                _context.SaveChanges();
            }

            return await Task.FromResult(new ResultadoExecucaoQuery<int>
            {
                ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Sucesso
            });
        }
    }
}
