using API_Camiones.Modelos;
using API_Camiones.Services;
using Microsoft.EntityFrameworkCore;

namespace API_Camiones.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Carga> Cargas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<Amortizacion> Amortizacion { get; set; } = default!;
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
