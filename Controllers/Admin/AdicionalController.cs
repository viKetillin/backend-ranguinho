using ApiCardapio.Data;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Models;
using ApiCardapio.Querys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiCardapio.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    public class AdicionalController : MainController
    {
        private readonly IAdicionalService _adicionalService;
        private readonly Contexto _context;

        public AdicionalController(Contexto context, IAdicionalService adicionalService)
        {
            _adicionalService = adicionalService;
            _context = context;
        }

        #region [GET]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpGet("adicionais")]
        public async Task<ActionResult<ResultadoExecucaoListaQuery<ListaAdicionaisEstabelecimentoQuery>>> GetAdicionais(int idEstabelecimento, int idCategoria)
        {
            return Ok(await _adicionalService.GetAdicionais(idEstabelecimento, idCategoria));
        }
        #endregion [GET]

        #region [POST]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpPost("adicional")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PostAdicional(AdicionalModel adicional)
        {
            return Ok(await _adicionalService.PostAdicional(adicional));
        }
        #endregion [POST]

        #region [PUT]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpPut("adicional")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PutAdicional(AdicionalModel adicional)
        {
            return Ok(await _adicionalService.PutAdicional(adicional));
        }
        #endregion [PUT]

        #region [DELETE]

        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpDelete("adicional{id}")]
        public async Task<ActionResult<ResultadoExecucaoQuery<IngredienteModel>>> DeleteAdicional(int id)
        {
            return Ok(await _adicionalService.DeleteAdicional(id));
        }
        #endregion [DELETE]
    }
}
