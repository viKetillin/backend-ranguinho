using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCardapio.Data;
using ApiCardapio.Models;

namespace ApiCardapio.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class PedidosIngredientesController : ControllerBase
    {
        private readonly Contexto _context;

        public PedidosIngredientesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/PedidosIngredientes
        [HttpGet("recuperarPedidoIngredientes")]
        public async Task<ActionResult<IEnumerable<PedidoIngredienteModel>>> GetPedidosIngredientes()
        {
            //return await _context.PedidosIngredientes.ToListAsync();

            var pedidos = await _context.PedidosIngredientes.FromSqlRaw("SELECT PC.NOMEPONTOCARNE, " +
                                                                        "PR.NOMEPRODUTO," +
                                                                        "GROUP_CONCAT(DISTINCT I.NomeIngrediente ORDER BY I.NomeIngrediente ASC SEPARATOR ', ') AS INGREDIENTESPEDIDO, " +
                                                                        "GROUP_CONCAT(DISTINCT pa.NomeProduto ORDER BY pa.NomeProduto ASC SEPARATOR ', ') AS ADICIONAL " +
                                                                    "FROM PRODUTOPEDIDO PP " +
                                                                        "INNER JOIN PEDIDOINGREDIENTE PI ON PP.ID = PI.ProdutoPedidoId " +        
                                                                        "LEFT JOIN INGREDIENTE I ON I.ID = PI.IngredienteId " +
                                                                        "LEFT JOIN PRODUTO PA ON PA.ID = PI.ProdutoId " +        
                                                                        "INNER JOIN PEDIDO P ON P.ID = PP.PEDIDOID " +
                                                                        "INNER JOIN PONTOCARNE PC ON PC.ID = PP.PONTOCARNEID " +                                                                        
                                                                        "INNER JOIN PRODUTOESTABELECIMENTO PF ON PF.ID = PP.PRODUTOESTABELECIMENTOID " +
                                                                        "LEFT JOIN PRODUTO PR ON PR.ID = PF.PRODUTOID " +
                                                                        "INNER JOIN PRODUTOINGREDIENTE PRI ON PRI.PRODUTOID = P.ID " +
                                                                        "LEFT JOIN PRODUTOESTABELECIMENTO VA ON VA.PRODUTOID = PI.PRODUTOID " +
                                                                   "WHERE P.ID = 1 " +
                                                                   "GROUP BY PR.NOMEPRODUTO").ToListAsync();

            return pedidos;
        }

        // GET: api/PedidosIngredientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoIngredienteModel>> GetPedidoIngrediente(int id)
        {
            var pedidoIngrediente = await _context.PedidosIngredientes.FindAsync(id);

            if (pedidoIngrediente == null)
            {
                return NotFound();
            }

            return pedidoIngrediente;
        }

        // PUT: api/PedidosIngredientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoIngrediente(int id, PedidoIngredienteModel pedidoIngrediente)
        {
            if (id != pedidoIngrediente.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedidoIngrediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoIngredienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PedidosIngredientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("adicionarPedidoIngrediente")]
        public async Task<ActionResult<PedidoIngredienteModel>> PostPedidoIngrediente(PedidoIngredienteModel pedidoIngrediente)
        {
            _context.PedidosIngredientes.Add(pedidoIngrediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoIngrediente", new { id = pedidoIngrediente.Id }, pedidoIngrediente);
        }

        // DELETE: api/PedidosIngredientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoIngrediente(int id)
        {
            var pedidoIngrediente = await _context.PedidosIngredientes.FindAsync(id);
            if (pedidoIngrediente == null)
            {
                return NotFound();
            }

            _context.PedidosIngredientes.Remove(pedidoIngrediente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoIngredienteExists(int id)
        {
            return _context.PedidosIngredientes.Any(e => e.Id == id);
        }
    }
}
