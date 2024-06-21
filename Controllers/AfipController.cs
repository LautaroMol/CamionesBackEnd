using API_Camiones.Services;
using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("api/[controller]")]
public class AfipController : ControllerBase
{
    private readonly AfipService _afipService;

    public AfipController(AfipService afipService)
    {
        _afipService = afipService;
    }

    [HttpGet("crearTRA")]
    public IActionResult CrearTRA(string servicio)
    {
        string traXml = _afipService.CrearTRA(servicio);
        return Ok(traXml);
    }

    [HttpGet("validarCertificado")]
    public IActionResult ValidarCertificado()
    {
        var resultado = _afipService.ValidarCertificado();
        var (esValido, fechaVencimiento, detallesCadena) = resultado;

        if (!esValido)
        {
            return BadRequest(new { Mensaje = "El certificado no es válido.", DetallesCadena = detallesCadena });
        }

        return Ok(new { Mensaje = "El certificado es válido.", FechaVencimiento = fechaVencimiento, DetallesCadena = detallesCadena });
    }
}