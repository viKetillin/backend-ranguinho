using ApiCardapio.Data;
using ApiCardapio.Interfaces.Services;
using ApiCardapio.Querys;
using ApiCardapio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiCardapio.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    public class HorarioFuncionamentoController : MainController
    {
        private readonly Contexto _context;
        private readonly IHorarioFuncionamentoService _horarioFuncionamentoService;

        public HorarioFuncionamentoController(Contexto context, IHorarioFuncionamentoService horarioFuncionamentoService)
        {
            _context = context;
            _horarioFuncionamentoService = horarioFuncionamentoService;
        }

        #region [GET]
        [Authorize(Roles = "Admin, Proprietário")]
        [HttpGet("horario-funcionamento{idEstabelecimento}")]
        public async Task<ActionResult<ResultadoExecucaoListaQuery<DiaHorarioFuncionamentoQuery>>> GetHorarioFuncionamento(int idEstabelecimento)
        {
            return Ok(await _horarioFuncionamentoService.GetHorarioFuncionamento(idEstabelecimento));
        }
        #endregion [GET]

        #region [DELETE]     
        [Authorize(Roles = "Admin, Proprietário")]
        [HttpDelete("horario-funcionamento{id}")]
        public async Task<ActionResult<ResultadoExecucaoQuery<int>>> DeleteHorarioFuncionamento(int id)
        {
            return Ok(await _horarioFuncionamentoService.DeleteHorarioFuncionamento(id));
        }
        #endregion [DELETE]
    }
}
