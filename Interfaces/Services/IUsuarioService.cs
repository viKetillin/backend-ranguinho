using ApiCardapio.Commands;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiCardapio.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<PerfilUsuarioModel> RecuperarUsuarioLogin(string usuario, string senha);
        Task<UsuarioEstabelecimentoModel> RecuperarEstabelecimentoUsuario(string usuario);
        Task<PerfilUsuarioModel> RecuperarUsuario(string username);
        #region [GET]        
        Task<ResultadoExecucaoListaQuery<UsuariosQuery>> GetUsuarios();
        Task<ResultadoExecucaoListaQuery<PerfilModel>> GetPerfis();
        #endregion [GET]

        #region [POST]        
        Task<ResultadoExecucaoQuery<int>> PostUsuario([FromBody] UsuarioCommand usuarioCommand);
        #endregion [POST]

        #region [PUT]
        Task<ResultadoExecucaoQuery<int>> PutUsuario([FromBody] UsuarioCommand usuarioCommand);
        #endregion [PUT]

        #region [DELETE]        
        Task<ResultadoExecucaoQuery<int>> DeleteUsuario(int id);
        #endregion [DELETE]


    }
}
