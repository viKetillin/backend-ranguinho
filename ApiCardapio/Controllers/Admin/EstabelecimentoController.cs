using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiCardapio.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class EstabelecimentoController : MainController
    {
        private readonly IEstabelecimentoService _estabelecimentoService;
        public EstabelecimentoController(IEstabelecimentoService estabelecimentoService)
        {
            _estabelecimentoService = estabelecimentoService;
        }

        #region [GET]
        [Authorize(Roles = "Admin, Proprietário")]
        [HttpGet("estabelecimento")]
        public async Task<ActionResult<ResultadoExecucaoListaQuery<EstabelecimentoModel>>> GetEstabelecimentos()
        {                        
            return Ok(await _estabelecimentoService.GetEstabelecimentos(GetUserFromToken()));
        }

        [Authorize(Roles = "Admin, Proprietário")]
        [HttpGet("estabelecimento{link}")]
        public async Task<ActionResult<ResultadoExecucaoQuery<EstabelecimentoModel>>> GetEstabelecimento(string link)
        {
            return Ok(await _estabelecimentoService.GetEstabelecimento(link));
        }
        #endregion [GET]

        #region [POST]
        [Authorize(Roles = "Admin, Proprietário")]
        [HttpPost("estabelecimento")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PostEstabelecimento([FromForm] EstabelecimentoCommand estabelecimentoCommand)
        {
            return Ok(await _estabelecimentoService.PostEstabelecimento(estabelecimentoCommand, GetUserFromToken()));
        }
        #endregion [POST]

        #region [PUT]
        [Authorize(Roles = "Admin, Proprietário")]
        [HttpPut("estabelecimento")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PutEstabelecimento([FromForm] EstabelecimentoCommand estabelecimentoCommand)
        {
            return Ok(await _estabelecimentoService.PutEstabelecimento(estabelecimentoCommand));
        }
        #endregion [PUT]

        #region [DELETE]
        [Authorize(Roles = "Admin, Proprietário")]
        [HttpDelete("estabelecimento{id}")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> DeleteEstabelecimento(int id)
        {       
            return Ok(await _estabelecimentoService.DeleteEstabelecimento(id));
        }
        #endregion [DELETE]
    }
}
