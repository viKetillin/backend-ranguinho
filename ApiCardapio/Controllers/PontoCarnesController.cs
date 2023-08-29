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
    public class PontoCarnesController : ControllerBase
    {
        private readonly Contexto _context;

        public PontoCarnesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/PontoCarnes
        [HttpGet("recuperarPontosCarne")]
        public async Task<ActionResult<IEnumerable<PontoCarneModel>>> GetPontosCarne()
        {
            return await _context.PontosCarne.ToListAsync();
        }

        // GET: api/PontoCarnes/5
        [HttpGet("recuperarPontoCarne")]
        public async Task<ActionResult<PontoCarneModel>> GetPontoCarne(int id)
        {
            var pontoCarne = await _context.PontosCarne.FindAsync(id);

            if (pontoCarne == null)
            {
                return NotFound();
            }

            return pontoCarne;
        }

        // PUT: api/PontoCarnes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPontoCarne(int id, PontoCarneModel pontoCarne)
        {
            if (id != pontoCarne.Id)
            {
                return BadRequest();
            }

            _context.Entry(pontoCarne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PontoCarneExists(id))
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

        // POST: api/PontoCarnes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PontoCarneModel>> PostPontoCarne(PontoCarneModel pontoCarne)
        {
            _context.PontosCarne.Add(pontoCarne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPontoCarne", new { id = pontoCarne.Id }, pontoCarne);
        }

        // DELETE: api/PontoCarnes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePontoCarne(int id)
        {
            var pontoCarne = await _context.PontosCarne.FindAsync(id);
            if (pontoCarne == null)
            {
                return NotFound();
            }

            _context.PontosCarne.Remove(pontoCarne);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PontoCarneExists(int id)
        {
            return _context.PontosCarne.Any(e => e.Id == id);
        }
    }
}
