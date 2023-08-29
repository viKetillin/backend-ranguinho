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
    public class IngredienteController : ControllerBase
    {
        private readonly IIngredienteService _ingredienteService;

        public IngredienteController(IIngredienteService ingredienteService)
        {
            _ingredienteService = ingredienteService;            
        }

        #region [GET]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpGet("ingredientes{estabelecimentoId}")]
        public async Task<ActionResult<ResultadoExecucaoListaQuery<IngredienteModel>>> GetIngredientes(int estabelecimentoId)
        {
            return Ok(await _ingredienteService.GetIngredientes(estabelecimentoId));
        }
        #endregion [GET]

        #region [POST]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpPost("ingrediente")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PostIngrediente(IngredienteModel ingrediente)
        {
            return Ok(await _ingredienteService.PostIngrediente(ingrediente));
        }
        #endregion [POST]

        #region [PUT]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpPut("ingrediente")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PutIngrediente(IngredienteModel ingrediente)
        {
            return Ok(await _ingredienteService.PutIngrediente(ingrediente));
        }
        #endregion [PUT]              

        #region [DELETE]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpDelete("ingrediente{id}")]
        public async Task<ActionResult<ResultadoExecucaoQuery<IngredienteModel>>> DeleteIngrediente(int id)
        {
            return Ok(await _ingredienteService.DeleteIngrediente(id));
        }
        #endregion [DELETE]
    }
}
