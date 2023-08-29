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
    public class CategoriaEstabelecimentoController : MainController
    {
        private readonly ICategoriaEstabelecimentoService _categoriaEstabelecimentoService;
        public CategoriaEstabelecimentoController(ICategoriaEstabelecimentoService categoriaEstabelecimentoService)
        {
            _categoriaEstabelecimentoService = categoriaEstabelecimentoService;
        }

        #region [GET]
        [HttpGet("categorias-estabelecimento")]
        public async Task<ActionResult<ResultadoExecucaoListaQuery<CategoriaEstabelecimentoModel>>> GetCategoriasEstabelecimento()
        {
            return Ok(await _categoriaEstabelecimentoService.GetCategoriasEstabelecimento());
        }
        #endregion [GET]

        #region [POST]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpPost("categoria-estabelecimento")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PostCategoriaEstabelecimento(CategoriaEstabelecimentoModel categoriaEstabelecimento)
        {
            return Ok(await _categoriaEstabelecimentoService.PostCategoriaEstabelecimento(categoriaEstabelecimento));
        }
        #endregion [POST]

        #region [PUT]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpPut("categoria-estabelecimento")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PutCategoriaEstabelecimento(CategoriaEstabelecimentoModel categoriaEstabelecimento)
        {
            return Ok(await _categoriaEstabelecimentoService.PutCategoriaEstabelecimento(categoriaEstabelecimento));
        }
        #endregion [PUT]
    }
}
