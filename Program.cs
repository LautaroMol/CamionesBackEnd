using API_Camiones.Data;
using API_Camiones.DTOs;
using API_Camiones.Interfaces;
using API_Camiones.Interfaces_y_Repo;
using API_Camiones.Modelos;
using API_Camiones.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

builder.Services.AddScoped<ICarga, CargaRepositorio>();
builder.Services.AddScoped<ICategoria, CategoriaRepositorio>();
builder.Services.AddScoped<ICliente, ClienteRepositorio>();
builder.Services.AddScoped<IFactura, FacturaRepositorio>();
builder.Services.AddScoped<IGasto, GastoRepositorio>();
builder.Services.AddScoped<IUsuario, UsuarioRepositorio>();
builder.Services.AddScoped<IViaje, ViajeRepositorio>();
builder.Services.AddScoped<IAmortizacion, AmortizacionRepositorio>();
builder.Services.AddScoped<IUnidad, UnidadRepositorio>();

var afipConfig = builder.Configuration.GetSection("AfipConfig");
var certificadoPath = afipConfig["CertificadoPath"];
var certificadoPassword = afipConfig["CertificadoPassword"];
builder.Services.AddSingleton(new AfipService(certificadoPath, certificadoPassword));

builder.Services.AddCors(options =>
{
    options.AddPolicy("politicaNueva", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

#region Carga Endpoints
app.MapGet("carga/lista", async (ICarga _cargaService) =>
{
    var listaCarga = await _cargaService.GetList();
    return listaCarga.Count > 0 ? Results.Ok(listaCarga) : Results.NotFound();
});

app.MapGet("carga/{id}", async (int id, ICarga _cargaService) =>
{
    var carga = await _cargaService.GetId(id);
    return carga != null ? Results.Ok(carga) : Results.NotFound();
});

app.MapPost("carga/add", async ([FromBody] Carga modelo, ICarga _cargaService) =>
{
    var carga = await _cargaService.Add(modelo);
    return Results.Created($"/carga/{carga.IdCarga}", carga);
});

app.MapPut("carga/update/{id}", async (int id, [FromBody] Carga modelo, ICarga _cargaService) =>
{
    var encontrado = await _cargaService.GetId(id);
    if (encontrado is null) return Results.NotFound();

    encontrado.Codigo = modelo.Codigo;
    encontrado.Subtotal = modelo.Subtotal;
    encontrado.Producto = modelo.Producto;
    encontrado.Cantidad = modelo.Cantidad;
    encontrado.UnidadDeMedida = modelo.UnidadDeMedida;
    encontrado.PrecioUnit = modelo.PrecioUnit;
    encontrado.Bonif = modelo.Bonif;
    encontrado.Iva = modelo.Iva;
    encontrado.IdViaje = modelo.IdViaje;

    var success = await _cargaService.Update(encontrado);
    return success ? Results.Ok(encontrado) : Results.StatusCode(StatusCodes.Status500InternalServerError);
});

app.MapDelete("carga/delete/{id}", async (int id, ICarga _cargaService) =>
{
    var carga = await _cargaService.GetId(id);
    if (carga == null) return Results.NotFound();
    carga.Borrado = true;
    var success = await _cargaService.Update(carga);
    return success ? Results.Ok() : Results.StatusCode(StatusCodes.Status500InternalServerError);
});
#endregion

#region Categoria Endpoints
app.MapGet("categoria/lista", async (ICategoria _categoriaService) =>
{
    var listaCategoria = await _categoriaService.GetList();
    return listaCategoria.Count > 0 ? Results.Ok(listaCategoria) : Results.NotFound();
});

app.MapGet("categoria/{id}", async (int id, ICategoria _categoriaService) =>
{
    var categoria = await _categoriaService.GetId(id);
    return categoria != null ? Results.Ok(categoria) : Results.NotFound();
});

app.MapPost("categoria/add", async ([FromBody] Categoria nuevaCategoria, ICategoria _categoriaService) =>
{
    var categoriaAgregada = await _categoriaService.Add(nuevaCategoria);
    return Results.Created($"/categoria/{categoriaAgregada.IdCategoria}", categoriaAgregada);
});

app.MapPut("categoria/update/{id}", async (int id, [FromBody] Categoria categoriaActualizada, ICategoria _categoriaService) =>
{
    var encontrado = await _categoriaService.GetId(id);
    if (encontrado is null) return Results.NotFound();
    encontrado.Nombre = categoriaActualizada.Nombre;

    var actualizado = await _categoriaService.Update(encontrado);
    return actualizado ? Results.Ok(encontrado) : Results.StatusCode(StatusCodes.Status500InternalServerError);
});

app.MapDelete("categoria/delete/{id}", async (int id, ICategoria _categoriaService) =>
{
    var categoria = await _categoriaService.GetId(id);
    if (categoria == null) return Results.NotFound();
    categoria.Borrado = true;
    var eliminado = await _categoriaService.Update(categoria);
    return eliminado ? Results.Ok() : Results.StatusCode(StatusCodes.Status500InternalServerError);
});
#endregion

#region Cliente Endpoints
app.MapGet("cliente/lista", async (ICliente _clienteService) =>
{
    var listaCliente = await _clienteService.GetList();
    return listaCliente.Count > 0 ? Results.Ok(listaCliente) : Results.NotFound();
});

app.MapGet("cliente/{id}", async (int id, ICliente _clienteService) =>
{
    var cliente = await _clienteService.GetId(id);
    return cliente != null ? Results.Ok(cliente) : Results.NotFound();
});

app.MapPost("cliente/add", async ([FromBody] Cliente nuevoCliente, ICliente _clienteService) =>
{
    var clienteAgregado = await _clienteService.Add(nuevoCliente);
    return Results.Created($"/cliente/{clienteAgregado.IdCliente}", clienteAgregado);
});

app.MapPut("cliente/update/{id}", async (int id, [FromBody] Cliente clienteActualizado, ICliente _clienteService) =>
{
    var encontrado = await _clienteService.GetId(id);
    if (encontrado is null) return Results.NotFound();

    encontrado.RazonSoc = clienteActualizado.RazonSoc;
    encontrado.Domicilio = clienteActualizado.Domicilio;
    encontrado.Condicion = clienteActualizado.Condicion;
    encontrado.CuitCliente = clienteActualizado.CuitCliente;
    encontrado.Borrado = clienteActualizado.Borrado;

    var actualizado = await _clienteService.Update(encontrado);
    return actualizado ? Results.Ok(encontrado) : Results.StatusCode(StatusCodes.Status500InternalServerError);
});

app.MapDelete("cliente/delete/{id}", async (int id, ICliente _clienteService) =>
{
    var cliente = await _clienteService.GetId(id);
    if (cliente == null) return Results.NotFound();
    cliente.Borrado = true;
    var eliminado = await _clienteService.Update(cliente);
    return eliminado ? Results.Ok() : Results.StatusCode(StatusCodes.Status500InternalServerError);
});
#endregion
#region Factura Endpoints
app.MapGet("factura/lista", async (IFactura _facturaService) =>
{
    var listaFactura = await _facturaService.GetList();
    return listaFactura.Count > 0 ? Results.Ok(listaFactura) : Results.NotFound();
});

app.MapGet("factura/{id}", async (int id, IFactura _facturaService) =>
{
    var factura = await _facturaService.GetId(id);
    return factura != null ? Results.Ok(factura) : Results.NotFound();
});

app.MapPost("factura/add", async ([FromBody] Factura nuevaFactura, IFactura _facturaService) =>
{
    var facturaAgregada = await _facturaService.Add(nuevaFactura);
    return Results.Created($"/factura/{facturaAgregada.IdFactura}", facturaAgregada);
});

app.MapPut("factura/update/{id}", async (int id, [FromBody] Factura facturaActualizada, IFactura _facturaService) =>
{
    var encontrado = await _facturaService.GetId(id);
    if (encontrado is null) return Results.NotFound();

    encontrado.CuitUsuario = facturaActualizada.CuitUsuario;
    encontrado.CuitCliente = facturaActualizada.CuitCliente;
    encontrado.Cargas = facturaActualizada.Cargas;
    encontrado.Cuit = facturaActualizada.Cuit;
    encontrado.Borrado = facturaActualizada.Borrado;

    var actualizado = await _facturaService.Update(encontrado);
    return actualizado ? Results.Ok(encontrado) : Results.StatusCode(StatusCodes.Status500InternalServerError);
});

app.MapDelete("factura/delete/{id}", async (int id, IFactura _facturaService) =>
{
    var factura = await _facturaService.GetId(id);
    if (factura == null) return Results.NotFound();
    factura.Borrado = true;
    var eliminado = await _facturaService.Update(factura);
    return eliminado ? Results.Ok() : Results.StatusCode(StatusCodes.Status500InternalServerError);
});
#endregion
#region Gasto Endpoints
app.MapGet("gasto/lista", async (IGasto _gastoService) =>
{
    var listaGastos = await _gastoService.GetList();
    return listaGastos.Count > 0 ? Results.Ok(listaGastos) : Results.NotFound();
});

app.MapGet("gasto/{id}", async (int id, IGasto _gastoService) =>
{
    var gasto = await _gastoService.GetId(id);
    return gasto != null ? Results.Ok(gasto) : Results.NotFound();
});

app.MapPost("gasto/add", async ([FromBody] Gasto nuevoGasto, IGasto _gastoService) =>
{
    var gastoAgregado = await _gastoService.Add(nuevoGasto);
    return Results.Created($"/gasto/{gastoAgregado.IdGasto}", gastoAgregado);
});

app.MapPut("gasto/update/{id}", async (int id, [FromBody] Gasto gastoActualizado, IGasto _gastoService) =>
{
    var encontrado = await _gastoService.GetId(id);
    if (encontrado is null) return Results.NotFound();

    encontrado.Nombre = gastoActualizado.Nombre;
    encontrado.Cantidad = gastoActualizado.Cantidad;
    encontrado.Categoria = gastoActualizado.Categoria;
    encontrado.Viaje = gastoActualizado.Viaje;
    encontrado.Fecha = gastoActualizado.Fecha;
    encontrado.Borrado = gastoActualizado.Borrado;

    var actualizado = await _gastoService.Update(encontrado);
    return actualizado ? Results.Ok(encontrado) : Results.StatusCode(StatusCodes.Status500InternalServerError);
});

app.MapDelete("gasto/delete/{id}", async (int id, IGasto _gastoService) =>
{
    var gasto = await _gastoService.GetId(id);
    if (gasto == null) return Results.NotFound();
    gasto.Borrado = true;
    var eliminado = await _gastoService.Update(gasto);
    return eliminado ? Results.Ok() : Results.StatusCode(StatusCodes.Status500InternalServerError);
});
#endregion
#region Usuario Endpoints
app.MapGet("usuario/lista", async (IUsuario _usuarioService) =>
{
    var listaUsuarios = await _usuarioService.GetList();
    return listaUsuarios.Count > 0 ? Results.Ok(listaUsuarios) : Results.NotFound();
});

app.MapGet("usuario/{id}", async (int id, IUsuario _usuarioService) =>
{
    var usuario = await _usuarioService.GetId(id);
    return usuario != null ? Results.Ok(usuario) : Results.NotFound();
});

app.MapPost("usuario/add", async ([FromBody] Usuario nuevoUsuario, IUsuario _usuarioService) =>
{
    var usuarioAgregado = await _usuarioService.Add(nuevoUsuario);
    return Results.Created($"/usuario/{usuarioAgregado.IdUsuario}", usuarioAgregado);
});

app.MapPut("usuario/update/{id}", async (int id, [FromBody] Usuario usuarioActualizado, IUsuario _usuarioService) =>
{
    var encontrado = await _usuarioService.GetId(id);
    if (encontrado is null) return Results.NotFound();

    encontrado.Razon = usuarioActualizado.Razon;
    encontrado.Domicilio = usuarioActualizado.Domicilio;
    encontrado.Condicion = usuarioActualizado.Condicion;
    encontrado.Cuit = usuarioActualizado.Cuit;
    encontrado.Facturas = usuarioActualizado.Facturas;
    encontrado.Borrado = usuarioActualizado.Borrado;

    var actualizado = await _usuarioService.Update(encontrado);
    return actualizado ? Results.Ok(encontrado) : Results.StatusCode(StatusCodes.Status500InternalServerError);
});

app.MapDelete("usuario/delete/{id}", async (int id, IUsuario _usuarioService) =>
{
    var usuario = await _usuarioService.GetId(id);
    if (usuario == null) return Results.NotFound();
    usuario.Borrado = true;
    var eliminado = await _usuarioService.Update(usuario);
    return eliminado ? Results.Ok() : Results.StatusCode(StatusCodes.Status500InternalServerError);
});
#endregion
#region Viaje

// Mapas para Viaje
app.MapGet("viaje/lista", async (IViaje _viajeService) =>
{
    var listaViajes = await _viajeService.GetList();
    if (listaViajes.Count > 0)
        return Results.Ok(listaViajes);
    else
        return Results.NotFound();
});

app.MapGet("viaje/{id}", async (int id, IViaje _viajeService) =>
{
    var viaje = await _viajeService.GetId(id);
    if (viaje != null)
        return Results.Ok(viaje);
    else
        return Results.NotFound();
});

app.MapPost("viaje/add", async ([FromBody] Viaje modelo, IViaje _viajeService) =>
{
    var viaje = await _viajeService.Add(modelo);
    return Results.Created($"/viaje/{viaje.IdViaje}", viaje);
});

app.MapPut("viaje/update/{id}", async (int id, [FromBody] Viaje modelo, IViaje _viajeService) =>
{
    var encontrado = await _viajeService.GetId(id);
    if (encontrado is null)
        return Results.NotFound();

    encontrado.Inicio = modelo.Inicio;
    encontrado.Final = modelo.Final;
    encontrado.Gastos = modelo.Gastos;
    encontrado.Fecha = modelo.Fecha;
    encontrado.Cp = modelo.Cp;
    encontrado.Facturado = modelo.Facturado;
    encontrado.CuitUsuario = modelo.CuitUsuario;
    encontrado.Distancia = modelo.Distancia;
    encontrado.Borrado = modelo.Borrado;

    var success = await _viajeService.Update(encontrado);
    if (success)
        return Results.Ok(encontrado);
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});

app.MapDelete("viaje/delete/{id}", async (int id, IViaje _viajeService) =>
{
    var viaje = await _viajeService.GetId(id);
    if (viaje == null)
        return Results.NotFound();

    viaje.Borrado = true;
    var success = await _viajeService.Update(viaje);
    if (success)
        return Results.Ok();
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
});

#endregion // Viaje
#region Unidad
app.MapGet("unidad/lista", async (IUnidad _unidadService) =>
{
    var listaUnidades = await _unidadService.GetList();
    return listaUnidades.Count > 0 ? Results.Ok(listaUnidades) : Results.NotFound();
});

app.MapGet("unidad/{id}", async (int id, IUnidad _unidadService) =>
{
    var unidad = await _unidadService.GetId(id);
    return unidad != null ? Results.Ok(unidad) : Results.NotFound();
});

app.MapPost("unidad/add", async ([FromBody] Unidad nuevaUnidad, IUnidad _unidadService) =>
{
    var unidadAgregada = await _unidadService.Add(nuevaUnidad);
    return Results.Created($"/unidad/{unidadAgregada.IdUnidad}", unidadAgregada);
});

app.MapPut("unidad/update/{id}", async (int id, [FromBody] Unidad unidadActualizada, IUnidad _unidadService) =>
{
    var encontrada = await _unidadService.GetId(id);
    if (encontrada is null) return Results.NotFound();

    encontrada.Marca = unidadActualizada.Marca;
    encontrada.Modelo = unidadActualizada.Modelo;
    encontrada.IdUsuario = unidadActualizada.IdUsuario;
    encontrada.Valoracion = unidadActualizada.Valoracion;
    encontrada.Amortizacion = unidadActualizada.Amortizacion;
    encontrada.Ruedas = unidadActualizada.Ruedas;
    encontrada.EstadoRueda = unidadActualizada.EstadoRueda;
    encontrada.Aceite = unidadActualizada.Aceite;
    encontrada.KmAceite = unidadActualizada.KmAceite;

    var actualizado = await _unidadService.Update(encontrada);
    return actualizado ? Results.Ok(encontrada) : Results.StatusCode(StatusCodes.Status500InternalServerError);
});

app.MapDelete("unidad/delete/{id}", async (int id, IUnidad _unidadService) =>
{
    var unidad = await _unidadService.GetId(id);
    if (unidad == null) return Results.NotFound();
    var eliminado = await _unidadService.Delete(unidad);
    return eliminado ? Results.Ok() : Results.StatusCode(StatusCodes.Status500InternalServerError);
});
#endregion
#region Amortizacion
app.MapGet("amortizacion/lista", async (IAmortizacion _amortizacionService) =>
{
    var listaAmortizaciones = await _amortizacionService.GetList();
    return listaAmortizaciones.Count > 0 ? Results.Ok(listaAmortizaciones) : Results.NotFound();
});

app.MapGet("amortizacion/{id}", async (int id, IAmortizacion _amortizacionService) =>
{
    var amortizacion = await _amortizacionService.GetId(id);
    return amortizacion != null ? Results.Ok(amortizacion) : Results.NotFound();
});

app.MapPost("amortizacion/add", async ([FromBody] Amortizacion nuevaAmortizacion, IAmortizacion _amortizacionService) =>
{
    var amortizacionAgregada = await _amortizacionService.Add(nuevaAmortizacion);
    return Results.Created($"/amortizacion/{amortizacionAgregada.IdAmortizacion}", amortizacionAgregada);
});

app.MapPut("amortizacion/update/{id}", async (int id, [FromBody] Amortizacion amortizacionActualizada, IAmortizacion _amortizacionService) =>
{
    var encontrada = await _amortizacionService.GetId(id);
    if (encontrada is null) return Results.NotFound();

    encontrada.Plazo = amortizacionActualizada.Plazo;
    encontrada.Periodo = amortizacionActualizada.Periodo;
    encontrada.Objetivo = amortizacionActualizada.Objetivo;
    encontrada.Porcentaje = amortizacionActualizada.Porcentaje;
    encontrada.Recaudado = amortizacionActualizada.Recaudado;

    var actualizado = await _amortizacionService.Update(encontrada);
    return actualizado ? Results.Ok(encontrada) : Results.StatusCode(StatusCodes.Status500InternalServerError);
});

app.MapDelete("amortizacion/delete/{id}", async (int id, IAmortizacion _amortizacionService) =>
{
    var amortizacion = await _amortizacionService.GetId(id);
    if (amortizacion == null) return Results.NotFound();
    var eliminado = await _amortizacionService.Delete(amortizacion);
    return eliminado ? Results.Ok() : Results.StatusCode(StatusCodes.Status500InternalServerError);
});

#endregion

app.UseCors("politicaNueva"); 
app.MapControllers();
app.Run();
