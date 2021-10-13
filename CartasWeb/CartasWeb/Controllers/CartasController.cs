using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartasWeb.Data;
using CartasWeb.Models;

namespace CartasWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CartasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cartas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carta>>> GetCartas()
        {
            return await _context.Cartas.ToListAsync();
        }

        // GET: api/Cartas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carta>> GetCarta(string id)
        {
            var carta = await _context.Cartas.FindAsync(id);

            if (carta == null)
            {
                return NotFound();
            }

            return carta;
        }

        // PUT: api/Cartas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarta(string id, Carta carta)
        {
            if (id != carta.NaipeId)
            {
                return BadRequest();
            }

            _context.Entry(carta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaExists(id))
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

        // POST: api/Cartas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carta>> PostCarta(Carta carta)
        {
            _context.Cartas.Add(carta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CartaExists(carta.NaipeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarta", new { id = carta.NaipeId }, carta);
        }

        // DELETE: api/Cartas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarta(string id)
        {
            var carta = await _context.Cartas.FindAsync(id);
            if (carta == null)
            {
                return NotFound();
            }

            _context.Cartas.Remove(carta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartaExists(string id)
        {
            return _context.Cartas.Any(e => e.NaipeId == id);
        }
    }
}
