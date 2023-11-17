using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndC.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using BackEndC.Data;

namespace BackEndC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregaController : ControllerBase
    {
        private readonly BackDbContext _context;

        public EntregaController(BackDbContext context)
        {
            _context = context;
        }

        // GET: api/Entrega
        [HttpGet]
        public async Task<IActionResult> GetEntregas()
        {
            var entregas = await _context.Entrega.ToListAsync();
            return Ok(entregas);
        }

        // GET: api/Entrega/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntrega(int id)
        {
            var entrega = await _context.Entrega.FindAsync(id);

            if (entrega == null)
            {
                return NotFound();
            }

            return Ok(entrega);
        }

        // POST: api/Entrega
        [HttpPost]
        public async Task<IActionResult> PostEntrega(Entrega entrega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Adicionar a Entrega ao contexto
            _context.Entrega.Add(entrega);

            // Salvar as alterações no contexto
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntrega", new { id = entrega.Id }, entrega);
        }

        // PUT: api/Entrega/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrega(int id, Entrega entrega)
        {
            if (id != entrega.Id)
            {
                return BadRequest();
            }

            _context.Entry(entrega).State = EntityState.Modified;

            try
            {
                // Salvar as alterações no contexto
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntregaExists(id))
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

        // DELETE: api/Entrega/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntrega(int id)
        {
            var entrega = await _context.Entrega.FindAsync(id);
            if (entrega == null)
            {
                return NotFound();
            }

            _context.Entrega.Remove(entrega);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntregaExists(int id)
        {
            return _context.Entrega.Any(e => e.Id == id);
        }
    }
}
