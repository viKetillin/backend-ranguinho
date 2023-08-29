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
    public class CategoriaProdutoController : MainController
    {
        private readonly ICategoriaProdutoService _categoriaService;
        public CategoriaProdutoController(ICategoriaProdutoService categoriaProdutoService)
        {
            _categoriaService = categoriaProdutoService;
        }

        #region [GET]
        [HttpGet("categorias-produto-exibidas-cardapio")]
        public async Task<ActionResult<ResultadoExecucaoListaQuery<CategoriaProdutoModel>>> GetCategoriasExibidasCardapio(int estabelecimentoId)
        {
            return Ok(await _categoriaService.GetCategoriasExibidasCardapio(estabelecimentoId));
        }
        #endregion [GET]

        #region [POST]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpPost("categoria-produto")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PostCategoriaProduto([FromForm] CategoriaProdutoCommand categoriaProduto)
        {
            return Ok(await _categoriaService.PostCategoriaProduto(categoriaProduto));
        }
        #endregion [POST]

        #region [PUT]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpPut("categoria-produto")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PutCategoriaProduto([FromForm] CategoriaProdutoCommand categoriaProduto)
        {
            return Ok(await _categoriaService.PutCategoriaProduto(categoriaProduto));
        }
        #endregion [PUT]
    }
}
