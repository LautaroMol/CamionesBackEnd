using API_Camiones.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API_Camiones.DTOs;
using API_Camiones.Interfaces;
using API_Camiones.Interfaces_y_Repo;
using API_Camiones.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

// Register repositories
builder.Services.AddScoped<ICarga, CargaRepositorio>();
builder.Services.AddScoped<ICategoria, CategoriaRepositorio>();
builder.Services.AddScoped<ICliente, ClienteRepositorio>();
builder.Services.AddScoped<IFactura, FacturaRepositorio>();
builder.Services.AddScoped<IGasto, GastoRepositorio>();
builder.Services.AddScoped<IUsuario, UsuarioRepositorio>();
builder.Services.AddScoped<IViaje, ViajeRepositorio>();

// Register AfipService with configuration
var afipConfig = builder.Configuration.GetSection("AfipConfig");
var certificadoPath = afipConfig["CertificadoPath"];
var certificadoPassword = afipConfig["CertificadoPassword"];
builder.Services.AddSingleton(new AfipService(certificadoPath, certificadoPassword));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
