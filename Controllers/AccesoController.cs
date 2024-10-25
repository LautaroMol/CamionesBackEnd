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
        public async Task<IActionResult> Regoster(UserDTO obj)
        {
            var modelUser = new User
            {
                Nombre = obj.Nombre,
                Correo = obj.Correo,
                Pass = _utilidades.encriptSHA256(obj.Pass)
            };

            await _dbContext.Users.AddAsync(modelUser);
            await _dbContext.SaveChangesAsync();

            if (modelUser.IdUser != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSucces = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSucces = false });
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



    }
}
