using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Camiones.Modelos;
using API_Camiones.DTOs;
using Microsoft.AspNetCore.Authorization;
using API_Camiones.Data;

namespace API_Camiones.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Utilidades _utilidades;
        public AccesoController(ApplicationDbContext dbContext, Utilidades utilidades)
        {
            _dbContext = dbContext;
            _utilidades = utilidades;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserDTO obj)
        {
            // Verificar si el correo ya está registrado
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Correo == obj.Correo);

            if (existingUser != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new { isSuccess = false, message = "El correo ya está registrado" });
            }

            var modelUser = new User
            {
                Nombre = obj.Nombre,
                Correo = obj.Correo,
                Pass = _utilidades.encriptSHA256(obj.Pass)
            };

            await _dbContext.Users.AddAsync(modelUser);
            await _dbContext.SaveChangesAsync();

            if (modelUser.IdUser != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { isSuccess = false, message = "Error al registrar el usuario" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO obj)
        {
            var userFound = await _dbContext.Users.Where(u =>
            u.Correo == obj.Correo && u.Pass == _utilidades.encriptSHA256(obj.Pass)
            ).FirstOrDefaultAsync();

            if (userFound == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.generateJWT(userFound) });
        }
        [HttpGet]
        [Route("ValidarToken")]
        public IActionResult ValidateToken([FromQuery]string token)
        {
            bool respuesta = _utilidades.validateToken(token);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<ActionResult<User>> GetUser()
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync();
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }

    }
}
