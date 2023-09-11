using ApiCardapio.Interfaces.Services;
using ApiCardapio.Querys;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiCardapio.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    public class NavegacaoController : MainController
    {        
        private readonly INavegacaoService _navegacaoService;

        public NavegacaoController(INavegacaoService navegacaoService)
        {            
            _navegacaoService = navegacaoService;
        }

        #region [GET]     
        [HttpGet("estabelecimentos")]
        public async Task<ActionResult<ResultadoExecucaoListaQuery<EstabelecimentoQuery>>> GetEstabelecimentos()
        {
            return Ok(await _navegacaoService.GetEstabelecimentos());
        }   
        
        [HttpGet("estabelecimento{link}")]
        public async Task<ActionResult<ResultadoExecucaoQuery<ListaEstabelecimentosQuery>>> GetEstabelecimento(string link)
        {
            return Ok(await _navegacaoService.GetEstabelecimento(link));
        }        
       
        [HttpGet("cardapio{idEstabelecimento}")]
        public async Task<ActionResult<ResultadoExecucaoListaQuery<CardapioQuery>>> GetCardapio(int idEstabelecimento)
        {
            return Ok(await _navegacaoService.GetCardapio(idEstabelecimento));
        }

        [HttpGet("horario-funcionamento{idEstabelecimento}")]
        public async Task<ActionResult<ResultadoExecucaoListaQuery<DiaHorarioFuncionamentoQuery>>> GetHorarioFuncionamento(int idEstabelecimento)
        {
            return Ok(await _navegacaoService.GetHorarioFuncionamento(idEstabelecimento));
        }
        #endregion [GET]
    }
}
