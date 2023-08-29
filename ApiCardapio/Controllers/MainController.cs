using ApiCardapio.Enumerators;
using ApiCardapio.Querys;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiCardapio.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(ResultadoExecucaoQuery rExecucao)
        {
            if (rExecucao.GetHttpStatusCode().HasValue)
                return StatusCode(rExecucao.GetHttpStatusCode().Value, rExecucao);
            else if (rExecucao.ResultadoExecucaoEnum == (int)ResultadoExecucaoEnum.Sucesso)
                return Ok(rExecucao);
            else
                return BadRequest(rExecucao);
        }

        protected UserFromTokenQuery GetUserFromToken()
        {
            var identity = (HttpContext.User.Identity as ClaimsIdentity);
                        
            if (identity != null)
            {
                UserFromTokenQuery usuario = new()
                {
                   CodigoUsuario = identity.Name,
                   Perfil = identity.FindFirst(ClaimTypes.Role).Value
                };
                return usuario;
            }
            else
                return null;
        }  
    }
}
