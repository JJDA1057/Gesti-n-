using GestionShared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionAPI.Data;

namespace GestionAPI.Controllers
{
    [Route("api/recursoespecializado")]
    [ApiController]
    public class RecursoEspecializadoController : ControllerBase
    {
        private readonly DataContext _context;

        public RecursoEspecializadoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/RecursoEspecializado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecursoEspe>>> GetRecursoEspecializados()
        {
            return await _context.RecursosEspe.ToListAsync();
        }

        // GET: api/RecursoEspecializado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecursoEspe>> GetRecursoEspecializado(int id)
        {
            var recursoEspecializado = await _context.RecursosEspe.FindAsync(id);

            if (recursoEspecializado == null)
            {
                return NotFound();
            }

            return recursoEspecializado;
        }

        // PUT: api/RecursoEspecializado/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecursoEspecializado(int id, RecursoEspe recursoEspecializado)
        {
            if (id != recursoEspecializado.Id)
            {
                return BadRequest();
            }

            _context.Entry(recursoEspecializado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoEspecializadoExists(id))
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

        // POST: api/RecursoEspecializado
        [HttpPost]
        public async Task<ActionResult<RecursoEspe>> PostRecursoEspecializado(RecursoEspe recursoEspecializado)
        {
            _context.RecursosEspe.Add(recursoEspecializado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecursoEspecializado", new { id = recursoEspecializado.Id }, recursoEspecializado);
        }

        // DELETE: api/RecursoEspecializado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecursoEspecializado(int id)
        {
            var recursoEspecializado = await _context.RecursosEspe.FindAsync(id);
            if (recursoEspecializado == null)
            {
                return NotFound();
            }

            _context.RecursosEspe.Remove(recursoEspecializado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecursoEspecializadoExists(int id)
        {
            return _context.RecursosEspe.Any(e => e.Id == id);
        }
    }
}