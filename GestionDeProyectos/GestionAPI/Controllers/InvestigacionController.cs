using GestionShared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionAPI.Data;
namespace GestionAPI.Controllers

{
    [Route("api/investigacion")]
    [ApiController]
    public class InvestigacionController : ControllerBase
    {
        private readonly DataContext _context;

        public InvestigacionController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Investigacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investigacion>>> GetInvestigaciones()
        {
            return await _context.Investigaciones.ToListAsync();
        }

        // GET: api/Investigacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investigacion>> GetInvestigacion(int id)
        {
            var investigacion = await _context.Investigaciones.FindAsync(id);

            if (investigacion == null)
            {
                return NotFound();
            }

            return investigacion;
        }

        // PUT: api/Investigacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestigacion(int id, Investigacion investigacion)
        {
            if (id != investigacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(investigacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestigacionExists(id))
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

        // POST: api/Investigacion
        [HttpPost]
        public async Task<ActionResult<Investigacion>> PostInvestigacion(Investigacion investigacion)
        {
            _context.Investigaciones.Add(investigacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvestigacion", new { id = investigacion.Id }, investigacion);
        }

        // DELETE: api/Investigacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestigacion(int id)
        {
            var investigacion = await _context.Investigaciones.FindAsync(id);
            if (investigacion == null)
            {
                return NotFound();
            }

            _context.Investigaciones.Remove(investigacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvestigacionExists(int id)
        {
            return _context.Investigaciones.Any(e => e.Id == id);
        }
    }
}