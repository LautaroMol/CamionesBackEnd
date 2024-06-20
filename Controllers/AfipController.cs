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
        try
        {
            bool certificadoValido = _afipService.ValidarCertificado();
            return Ok(certificadoValido ? "El certificado es válido" : "El certificado no es válido");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al validar el certificado: {ex.Message}");
        }
    }
}
