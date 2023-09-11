using ApiCardapio.Commands;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiCardapio.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize(Roles = "Admin, Proprietário")]
        [HttpGet("usuarios")]
        public async Task<ActionResult<ResultadoExecucaoListaQuery<UsuariosQuery>>> GetUsuarios()
        {
            return Ok(await _usuarioService.GetUsuarios());
        }

        [HttpGet("perfis")]
        public async Task<ActionResult<ResultadoExecucaoListaQuery<PerfilModel>>> GetPerfis()
        {
            return Ok(await _usuarioService.GetPerfis());
        }

        [Authorize(Roles = "Admin, Proprietário")]
        [HttpDelete("usuario")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> DeleteUsuario(int id)
        {
            return Ok(await _usuarioService.DeleteUsuario(id));
        }

        [Authorize(Roles = "Admin, Proprietário")]
        [HttpPost("usuario")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PostUsuario([FromBody] UsuarioCommand usuarioCommand)
        {
                return Ok(await _usuarioService.PostUsuario(usuarioCommand));
        }

        [Authorize(Roles = "Admin, Proprietário")]
        [HttpPut("usuario")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PutUsuario([FromBody] UsuarioCommand usuarioCommand)
        {
            return Ok(await _usuarioService.PutUsuario(usuarioCommand));
        }
    }
}
