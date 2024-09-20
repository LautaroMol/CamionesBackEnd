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
    [Route("api/Viajes")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;
        public ViajesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/Viajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viaje>>> GetViajes()
        {
            return await _context.Viajes.ToListAsync();
        }

        // GET: api/Viajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viaje>> GetViaje(int id)
        {
            var viaje = await _context.Viajes.FindAsync(id);

            if (viaje == null)
            {
                return NotFound();
            }

            return viaje;
        }

        [HttpGet("PDFs")]
        public IActionResult Pdf(string ruta)
        {
            string FilePath = ruta;
            if (System.IO.File.Exists(FilePath))
            {
                FileStream fs = new FileStream(ruta, FileMode.Open);
                return File(fs, "application/pdf", Path.GetFileName(ruta)); 
            }
            else
            {
                return Content("No encontrado.");
            }
        }

        // POST: api/Viajes/addPDF
        [HttpPost("addPDF")]
        public async Task<IActionResult> AddViaje([FromForm] Viaje viaje, IFormFile? archivo)
        {
            // Verificar si el objeto viaje es null
            if (viaje == null)
            {
                return BadRequest("No se ha proporcionado información del viaje.");
            }

            // Si se ha proporcionado un archivo, guardarlo en el servidor
            if (archivo != null && archivo.Length > 0)
            {
                // Asegurarse de que el directorio de subida existe
                var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "PDFs");
                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }

                // Generar un nombre único para el archivo
                var fileName = Path.GetFileName(archivo.FileName);
                var filePath = Path.Combine(uploadsDirectory, fileName);

                // Guardar el archivo en el servidor
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }

                // Asignar la ruta del archivo al campo Cp del viaje
                viaje.Cp = filePath;
            }

            // Guardar el viaje en la base de datos
            _context.Viajes.Add(viaje);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Viaje y archivo (si corresponde) guardados exitosamente.", viajeId = viaje.IdViaje });
        }

        // POST: api/Viajes/add
        [HttpPost("add")]
        public async Task<IActionResult> AddViaje([FromBody] Viaje viaje)
        {
            if (viaje == null)
            {
                return BadRequest("No se ha proporcionado información del viaje.");
            }

            // Guardar o actualizar el viaje en la base de datos
            if (viaje.IdViaje == 0)
            {
                _context.Viajes.Add(viaje);
            }
            else
            {
                _context.Viajes.Update(viaje);
            }

            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Viaje guardado exitosamente.", viajeId = viaje.IdViaje });
        }

        // POST: api/Viajes/addArchivo/{viajeId}
        [HttpPost("addArchivo/{viajeId}")]
        public async Task<IActionResult> AddArchivo(int viajeId, IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest("No se ha proporcionado ningún archivo.");
            }

            var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "PDFs");
            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            // Generar un nombre único para el archivo
            var fileName = Path.GetFileNameWithoutExtension(archivo.FileName);
            var fileExtension = Path.GetExtension(archivo.FileName);
            var filePath = Path.Combine(uploadsDirectory, archivo.FileName);

            int fileIndex = 1;
            while (System.IO.File.Exists(filePath))
            {
                filePath = Path.Combine(uploadsDirectory, $"{fileName}({fileIndex}){fileExtension}");
                fileIndex++;
            }

            using (var stream = System.IO.File.Create(filePath))
            {
                await archivo.CopyToAsync(stream);
            }


            var viaje = await _context.Viajes.FindAsync(viajeId);
            if (viaje != null)
            {
                viaje.Cp = filePath; 
                _context.Viajes.Update(viaje);
                await _context.SaveChangesAsync();
            }

            return Ok(new { mensaje = "Archivo guardado exitosamente.", filePath });
        }

        // PUT: api/Viajes/updateViajeConPdf/{id}
        [HttpPut("putPDF/{id}")]
        public async Task<IActionResult> UpdateViajeConPdf(int id, [FromForm] Viaje viaje, IFormFile? archivo)
        {

            var viajeExistente = await _context.Viajes.FindAsync(id);
            if (viajeExistente == null)
            {
                return NotFound("El viaje no existe.");
            }


            if (archivo != null && archivo.Length > 0)
            {

                var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }

                // Generar un nombre único para el archivo
                var fileName = archivo.FileName + Path.GetExtension(archivo.FileName);
                var filePath = Path.Combine(uploadsDirectory, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }

                viajeExistente.Cp = filePath;
            }

            viajeExistente.Final = viaje.Final;
            viajeExistente.Inicio = viaje.Inicio;
            viajeExistente.Fecha = viaje.Fecha;
            viajeExistente.Distancia = viaje.Distancia;
            viajeExistente.Gastos = viaje.Gastos;
            viajeExistente.Facturado = viaje.Facturado;
            viajeExistente.CuitUsuario = viaje.CuitUsuario;
            viajeExistente.Distancia = viaje.Distancia;
            viajeExistente.Borrado = viaje.Borrado;
            viajeExistente.TotalFacturado = viaje.TotalFacturado;

            // Guardar los cambios en la base de datos
            _context.Viajes.Update(viajeExistente);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Viaje y archivo (si corresponde) actualizados exitosamente.", viajeId = viajeExistente.IdViaje });
        }


        // DELETE: api/Viajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViaje(int id)
        {
            var viaje = await _context.Viajes.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }

            _context.Viajes.Remove(viaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViajeExists(int id)
        {
            return _context.Viajes.Any(e => e.IdViaje == id);
        }
    }
}
