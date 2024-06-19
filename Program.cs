using API_Camiones.Data;
using Microsoft.EntityFrameworkCore;
using LoginAFip;
using API_Camiones.DTOs;
using API_Camiones.Interfaces_y_Repo;
using API_Camiones.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));
builder.Services.AddScoped<ICarga, CargaRepositorio>();
builder.Services.AddScoped<ICategoria, CategoriaRepositorio>();
builder.Services.AddScoped<ICliente, ClienteRepositorio>();
builder.Services.AddScoped<IFactura, FacturaRepositorio>();
builder.Services.AddScoped<IGasto,GastoRepositorio>();
builder.Services.AddScoped<IUsuario, UsuarioRepositorio>();
builder.Services.AddScoped<IViaje, ViajeRepositorio>();

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
