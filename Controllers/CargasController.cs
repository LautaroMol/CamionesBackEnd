using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Camiones.Data;
using API_Camiones.Modelos;

namespace API_Camiones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CargasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cargas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carga>>> GetCargas()
        {
            return await _context.Cargas.ToListAsync();
        }

        // GET: api/Cargas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carga>> GetCarga(int id)
        {
            var carga = await _context.Cargas.FindAsync(id);

            if (carga == null)
            {
                return NotFound();
            }

            return carga;
        }

        // PUT: api/Cargas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarga(int id, Carga carga)
        {
            if (id != carga.Idcarga)
            {
                return BadRequest();
            }

            _context.Entry(carga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargaExists(id))
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

        // POST: api/Cargas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carga>> PostCarga(Carga carga)
        {
            _context.Cargas.Add(carga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarga", new { id = carga.Idcarga }, carga);
        }

        // DELETE: api/Cargas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarga(int id)
        {
            var carga = await _context.Cargas.FindAsync(id);
            if (carga == null)
            {
                return NotFound();
            }

            _context.Cargas.Remove(carga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CargaExists(int id)
        {
            return _context.Cargas.Any(e => e.Idcarga == id);
        }
    }
}
