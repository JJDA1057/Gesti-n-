using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionShared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionAPI.Data;

namespace GestionAPI.Controllers
{
    [Route("api/participaciones")]
    [ApiController]
    public class PartInvestigadoresController : ControllerBase
    {
        private readonly DataContext _context;

        public PartInvestigadoresController(DataContext context)
        {
            _context = context;
        }

        // GET: api/participaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartInvestigador>>> GetParticipaciones()
        {
            return await _context.PartInvestigadores.ToListAsync();
        }

        // POST: api/participaciones
        [HttpPost]
        public async Task<ActionResult<PartInvestigador>> PostParticipacion(PartInvestigador participacion)
        {
            _context.PartInvestigadores.Add(participacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipacion", new { id = participacion.Id }, participacion);
        }

        // GET: api/participaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartInvestigador>> GetParticipacion(int id)
        {
            var participacion = await _context.PartInvestigadores.FindAsync(id);

            if (participacion == null)
            {
                return NotFound();
            }

            return participacion;
        }

        // PUT: api/participaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipacion(int id, PartInvestigador participacion)
        {
            if (id != participacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(participacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipacionExists(id))
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

        // DELETE: api/participaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipacion(int id)
        {
            var participacion = await _context.PartInvestigadores.FindAsync(id);
            if (participacion == null)
            {
                return NotFound();
            }

            _context.PartInvestigadores.Remove(participacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipacionExists(int id)
        {
            return _context.PartInvestigadores.Any(e => e.Id == id);
        }
    }
}
