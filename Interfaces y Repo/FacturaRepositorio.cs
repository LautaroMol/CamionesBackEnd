using API_Camiones.Data;
using API_Camiones.Interfaces;
using API_Camiones.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API_Camiones.Interfaces_y_Repo
{
    public class FacturaRepositorio : IFactura
    {
        private readonly ApplicationDbContext _dbContext;
        public FacturaRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Factura> GetId(int IdFactura)
        {
            Factura factura = await _dbContext.Facturas.FindAsync(IdFactura);
            return factura;
        }

        public async Task<List<Factura>> GetList()
        {
            return await _dbContext.Facturas.ToListAsync();
        }
        public async Task<Factura> Add(Factura modelo)
        {
            await _dbContext.Facturas.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> Delete(Factura modelo)
        {
            try
            {
                Factura factura = await _dbContext.Facturas.FindAsync(modelo.Idfactura);
                if (factura == null)
                {
                    return false;
                }
                _dbContext.Facturas.Remove(factura);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch { return false; }
        }

        public async Task<bool> Update(Factura modelo)
        {
            try
            {
                Factura factura = await _dbContext.Facturas.FindAsync(modelo.Idfactura);
                if (factura == null)
                {
                    return false;
                }
                _dbContext.Facturas.Update(factura);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
