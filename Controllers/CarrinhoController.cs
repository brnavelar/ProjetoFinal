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
    public class CarrinhoController : ControllerBase
    {
        private readonly BackDbContext _context;

        public CarrinhoController(BackDbContext context)
        {
            _context = context;
        }

        // GET: api/Carrinho
        [HttpGet]
        public async Task<IActionResult> GetCarrinhos()
        {
            var carrinhos = await _context.Carrinho.ToListAsync();
            return Ok(carrinhos);
        }

        // GET: api/Carrinho/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarrinho(int id)
        {
            var carrinho = await _context.Carrinho.FindAsync(id);

            if (carrinho == null)
            {
                return NotFound();
            }

            return Ok(carrinho);
        }

        // POST: api/Carrinho
        [HttpPost]
        public async Task<IActionResult> PostCarrinho(Carrinho carrinho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Adicionar o Carrinho ao contexto
            _context.Carrinho.Add(carrinho);

            // Salvar as alterações no contexto
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrinho", new { id = carrinho.Id }, carrinho);
        }

        // PUT: api/Carrinho/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrinho(int id, Carrinho carrinho)
        {
            if (id != carrinho.Id)
            {
                return BadRequest();
            }

            _context.Entry(carrinho).State = EntityState.Modified;

            try
            {
                // Salvar as alterações no contexto
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrinhoExists(id))
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

        // DELETE: api/Carrinho/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrinho(int id)
        {
            var carrinho = await _context.Carrinho.FindAsync(id);
            if (carrinho == null)
            {
                return NotFound();
            }

            _context.Carrinho.Remove(carrinho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarrinhoExists(int id)
        {
            return _context.Carrinho.Any(e => e.Id == id);
        }
    }
}
