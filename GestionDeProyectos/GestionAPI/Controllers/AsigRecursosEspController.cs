using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionShared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionAPI.Data;

namespace GestionAPI.Controllers
{
    [Route("api/asigrecursosesp")]
    [ApiController]
    public class AsigRecursoEspController : ControllerBase
    {
        private readonly DataContext _context;

        public AsigRecursoEspController(DataContext context)
        {
            _context = context;
        }

        // GET: api/asigrecursosesp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsigRecursoEsp>>> GetAsigRecursosEsp()
        {
            return await _context.AsigRecursosEsp.ToListAsync();
        }

        // POST: api/asigrecursosesp
        [HttpPost]
        public async Task<ActionResult<AsigRecursoEsp>> PostAsigRecursoEsp(AsigRecursoEsp asigRecursoEsp)
        {
            _context.AsigRecursosEsp.Add(asigRecursoEsp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsigRecursoEsp", new { id = asigRecursoEsp.Id }, asigRecursoEsp);
        }

        // GET: api/asigrecursosesp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsigRecursoEsp>> GetAsigRecursoEsp(int id)
        {
            var asigRecursoEsp = await _context.AsigRecursosEsp.FindAsync(id);

            if (asigRecursoEsp == null)
            {
                return NotFound();
            }

            return asigRecursoEsp;
        }

        // PUT: api/asigrecursosesp/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsigRecursoEsp(int id, AsigRecursoEsp asigRecursoEsp)
        {
            if (id != asigRecursoEsp.Id)
            {
                return BadRequest();
            }

            _context.Entry(asigRecursoEsp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsigRecursoEspExists(id))
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

        // DELETE: api/asigrecursosesp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsigRecursoEsp(int id)
        {
            var asigRecursoEsp = await _context.AsigRecursosEsp.FindAsync(id);
            if (asigRecursoEsp == null)
            {
                return NotFound();
            }

            _context.AsigRecursosEsp.Remove(asigRecursoEsp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsigRecursoEspExists(int id)
        {
            return _context.AsigRecursosEsp.Any(e => e.Id == id);
        }
    }
}