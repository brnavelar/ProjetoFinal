using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndC.Data;
using BackEndC.Models;

namespace BackEndC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly BackDbContext _context;

        public VendedorController(BackDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetVendedores()
        {
            return await _context.Vendedor.ToListAsync();
        }

        // GET: api/Vendedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(string id)
        {
            var vendedor = await _context.Vendedor.FindAsync(id);

            if (vendedor == null)
            {
                return NotFound();
            }

            return vendedor;
        }

        // POST: api/Vendedor
        [HttpPost]
        public async Task<ActionResult<Vendedor>> PostVendedor(Vendedor vendedor)
        {
            _context.Vendedor.Add(vendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendedor", new { id = vendedor.Id }, vendedor);
        }

        // PUT: api/Vendedor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedor(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedorExists(id))
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

        private bool VendedorExists(int id)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Vendedor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendedor(string id)
        {
            var vendedor = await _context.Vendedor.FindAsync(id);

            if (vendedor == null)
            {
                return NotFound();
            }

            _context.Vendedor.Remove(vendedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool VendedorExists(string id)
        {
            return _context.Cliente.Any(e => e.Nome == id);
        }

    }
}
