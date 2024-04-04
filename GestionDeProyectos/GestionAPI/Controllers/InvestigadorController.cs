using GestionShared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionAPI.Data;

namespace GestionAPI.Controllers
{
    [Route("api/investigador")]
    [ApiController]
    public class InvestigadorController : ControllerBase
    {
        private readonly DataContext _context;

        public InvestigadorController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Investigador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investigador>>> GetInvestigadores()
        {
            return await _context.Investigadores.ToListAsync();
        }

        // GET: api/Investigador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investigador>> GetInvestigador(int id)
        {
            var investigador = await _context.Investigadores.FindAsync(id);

            if (investigador == null)
            {
                return NotFound();
            }

            return investigador;
        }

        // PUT: api/Investigador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestigador(int id, Investigador investigador)
        {
            if (id != investigador.Id)
            {
                return BadRequest();
            }

            _context.Entry(investigador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestigadorExists(id))
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

        // POST: api/Investigador
        [HttpPost]
        public async Task<ActionResult<Investigador>> PostInvestigador(Investigador investigador)
        {
            _context.Investigadores.Add(investigador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvestigador", new { id = investigador.Id }, investigador);
        }

        // DELETE: api/Investigador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestigador(int id)
        {
            var investigador = await _context.Investigadores.FindAsync(id);
            if (investigador == null)
            {
                return NotFound();
            }

            _context.Investigadores.Remove(investigador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvestigadorExists(int id)
        {
            return _context.Investigadores.Any(e => e.Id == id);
        }
    }
}