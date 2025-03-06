using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Models.Entity;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoEntitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProyectoEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProyectoEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProyectoEntity>>> GetProyectos()
        {
            return await _context.Proyectos.ToListAsync();
        }

        // GET: api/ProyectoEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProyectoEntity>> GetProyectoEntity(int id)
        {
            var proyectoEntity = await _context.Proyectos.FindAsync(id);

            if (proyectoEntity == null)
            {
                return NotFound();
            }

            return proyectoEntity;
        }

        // PUT: api/ProyectoEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyectoEntity(int id, ProyectoEntity proyectoEntity)
        {
            if (id != proyectoEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(proyectoEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoEntityExists(id))
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

        // POST: api/ProyectoEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProyectoEntity>> PostProyectoEntity(ProyectoEntity proyectoEntity)
        {
            _context.Proyectos.Add(proyectoEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyectoEntity", new { id = proyectoEntity.Id }, proyectoEntity);
        }

        // DELETE: api/ProyectoEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyectoEntity(int id)
        {
            var proyectoEntity = await _context.Proyectos.FindAsync(id);
            if (proyectoEntity == null)
            {
                return NotFound();
            }

            _context.Proyectos.Remove(proyectoEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProyectoEntityExists(int id)
        {
            return _context.Proyectos.Any(e => e.Id == id);
        }
    }
}
