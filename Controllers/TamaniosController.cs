using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyMVC.Models;

namespace ProyMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TamaniosController : ControllerBase
    {
        private readonly CineDbContext _context;

        public TamaniosController(CineDbContext context)
        {
            _context = context;
        }

        // GET: api/Tamanios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tamanio>>> GetTamanios()
        {
            return await _context.Tamanios.ToListAsync();
        }

        // GET: api/Tamanios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tamanio>> GetTamanio(int id)
        {
            var tamanio = await _context.Tamanios.FindAsync(id);

            if (tamanio == null)
            {
                return NotFound();
            }

            return tamanio;
        }

        // PUT: api/Tamanios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTamanio(int id, Tamanio tamanio)
        {
            if (id != tamanio.Id)
            {
                return BadRequest();
            }

            _context.Entry(tamanio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TamanioExists(id))
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

        // POST: api/Tamanios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tamanio>> PostTamanio(Tamanio tamanio)
        {
            _context.Tamanios.Add(tamanio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTamanio", new { id = tamanio.Id }, tamanio);
        }

        // DELETE: api/Tamanios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTamanio(int id)
        {
            var tamanio = await _context.Tamanios.FindAsync(id);
            if (tamanio == null)
            {
                return NotFound();
            }

            _context.Tamanios.Remove(tamanio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TamanioExists(int id)
        {
            return _context.Tamanios.Any(e => e.Id == id);
        }
    }
}
