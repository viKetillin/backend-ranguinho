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
    public class CardapioController : MainController
    {
        private readonly ICardapioService _cardapioService;        

        public CardapioController(ICardapioService cardapioService)
        {
            _cardapioService = cardapioService;
        }

        #region [GET]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpGet("cardapio{idEstabelecimento}")]
        public async Task<ActionResult<ResultadoExecucaoListaQuery<CardapioQuery>>> GetCardapio(int idEstabelecimento)
        {
            return Ok(await _cardapioService.GetCardapio(idEstabelecimento, GetUserFromToken()));
        }

        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpGet("produto")]
        public async Task<ActionResult<ResultadoExecucaoQuery<ProdutoQuery>>> GetProduto(int idEstabelecimento, int idProduto)
        {
            return Ok(await _cardapioService.GetProduto(idEstabelecimento, idProduto));
        }
        #endregion [GET]

        #region [POST]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpPost("produto")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PostProduto([FromBody] ProdutoCommand produtoCommand)
        {
            return Ok(await _cardapioService.PostProduto(produtoCommand));
        }
        #endregion [POST]

        #region [PUT]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpPut("produto")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> PutProduto([FromBody] ProdutoCommand produtoCommand)
        {
            return Ok(await _cardapioService.PutProduto(produtoCommand));
        }
        #endregion [PUT]

        #region [DELETE]
        [Authorize(Roles = "Admin, Proprietário, Franqueado")]
        [HttpDelete("produto{id}")]
        public async Task<ActionResult<ResultadoExecucaoQuery<ProdutoModel>>> DeleteProduto(int id)
        {
            return Ok(await _cardapioService.DeleteProduto(id));
        }
        #endregion [PUT]
    }
}
