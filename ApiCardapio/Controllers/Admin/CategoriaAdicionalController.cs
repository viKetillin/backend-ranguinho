using ApiCardapio.Commands;
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
    public class CategoriaAdicionalController : MainController
    {
        private readonly ICategoriaAdicionalService _categoriaAdicionalService;
        public CategoriaAdicionalController(ICategoriaAdicionalService categoriaAdicionalService)
        {
            _categoriaAdicionalService = categoriaAdicionalService;
        }

        #region [POST]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpPost("categoria-adicional")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PostCategoriaAdicional(CategoriaProdutoCommand categoriaAdicional)
        {
            return Ok(await _categoriaAdicionalService.PostCategoriaAdicional(categoriaAdicional));
        }
        #endregion [POST]

        #region [PUT]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpPut("categoria-adicional")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PutCategoriaAdicional(CategoriaAdicionalModel categoriaAdicional)
        {
            return Ok(await _categoriaAdicionalService.PutCategoriaAdicional(categoriaAdicional));
        }
        #endregion [PUT]
    }
}
