using ApiCardapio.Commands;
using ApiCardapio.Data;
using ApiCardapio.Enumerators;
using ApiCardapio.Interfaces.Repositories;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiCardapio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly Contexto _context;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, Contexto context)
        {
            _context = context;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<PerfilUsuarioModel> RecuperarUsuarioLogin(string usuario, string senha)
        {
            return await _usuarioRepository.RecuperarUsuarioLogin(usuario, senha);
        }

        public async Task<UsuarioEstabelecimentoModel> RecuperarEstabelecimentoUsuario(string usuario)
        {
            return await _usuarioRepository.RecuperarEstabelecimentoUsuario(usuario);
        }

        public async Task<PerfilUsuarioModel> RecuperarUsuario(string usuario)
        {
            return await _usuarioRepository.RecuperarUsuario(usuario);
        }

        public async Task<ResultadoExecucaoListaQuery<UsuariosQuery>> GetUsuarios()
        {
            return await _usuarioRepository.GetUsuarios();
        }

        public async Task<ResultadoExecucaoListaQuery<PerfilModel>> GetPerfis()
        {
            return await _usuarioRepository.GetPerfis();
        }

        public async Task<ResultadoExecucaoQuery<int>> DeleteUsuario(int id)
        {
            bool verificarSeUsuarioExiste = VerificarSeUsuarioExiste(id);
            if (!verificarSeUsuarioExiste)
            {
                return new ResultadoExecucaoQuery<int>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Usuário não encontrado!"
                };
            }
            else
                return await _usuarioRepository.DeleteUsuario(id);
        }

        public async Task<ResultadoExecucaoQuery<int>> PostUsuario([FromBody] UsuarioCommand usuarioCommand)
        {
            bool verificarSeExisteEmailCadastrado = VerificarSeExisteEmailCadastrado(usuarioCommand);
            bool verificarSeExisteCodigoUsuarioCadastrado = VerificarSeExisteCodigoUsuarioCadastrado(usuarioCommand);
            if (verificarSeExisteEmailCadastrado)
            {
                return new ResultadoExecucaoQuery<int>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Email já existe!"
                };
            }else if (verificarSeExisteCodigoUsuarioCadastrado)
            {
                return new ResultadoExecucaoQuery<int>
                {
                    ResultadoExecucaoEnum = (int)ResultadoExecucaoEnum.Erro,
                    Mensagem = "Código usuário já existe!"
                };
            }
            else
                return await _usuarioRepository.PostUsuario(usuarioCommand);
        }

        public async Task<ResultadoExecucaoQuery<int>> PutUsuario([FromBody] UsuarioCommand usuarioCommand)
        {
            return await _usuarioRepository.PutUsuario(usuarioCommand);
        }

        #region [Privados]
        private bool VerificarSeUsuarioExiste(int id) => _context.Usuarios.Any(e => e.Id == id);
        private bool VerificarSeExisteEmailCadastrado(UsuarioCommand usuarioCommand) => _context.Usuarios.Any(u => u.EmailUsuario == usuarioCommand.EmailUsuario);
        private bool VerificarSeExisteCodigoUsuarioCadastrado(UsuarioCommand usuarioCommand) => _context.Usuarios.Any(u => u.CodigoUsuario == usuarioCommand.CodigoUsuario);
        #endregion [Privados]
    }
}
