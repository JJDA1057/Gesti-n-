using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionShared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionAPI.Data;

namespace GestionAPI.Controllers
{

    [Route("api/actividades")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly DataContext _context;

        public ActividadesController(DataContext context)
        {
            _context = context;
        }
        // GET 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividadad>>> GetActividades()
        {
            return await _context.Actividades.ToListAsync();
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Actividadad>> PostActividad(Actividadad actividad)
        {
            _context.Actividades.Add(actividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActividad", new { id = actividad.Id }, actividad);
        }
        // GET id
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividadad>> GetActividad(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);

            if (actividad == null)
            {
                return NotFound();
            }

            return actividad;
        }

        // PUT: api/Actividades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividad(int id, Actividadad actividad)
        {
            if (id != actividad.Id)
            {
                return BadRequest();
            }

            _context.Entry(actividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadExists(id))
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

       

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividad(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            _context.Actividades.Remove(actividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActividadExists(int id)
        {
            return _context.Actividades.Any(e => e.Id == id);
        }
    }
}
