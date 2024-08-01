using API_Camiones.Data;
using API_Camiones.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Camiones.Interfaces_y_Repo
{
    public class AmortizacionRepositorio : IAmortizacion
    {
        private readonly ApplicationDbContext _dbContext;

        public AmortizacionRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Amortizacion> GetId(int idAmortizacion)
        {
            Amortizacion amortizacion = await _dbContext.Amortizacion.FindAsync(idAmortizacion);
            return amortizacion;
        }

        public async Task<List<Amortizacion>> GetList()
        {
            List<Amortizacion> lista = await _dbContext.Amortizacion.ToListAsync();
            return lista;
        }

        public async Task<Amortizacion> Add(Amortizacion modelo)
        {
            await _dbContext.Amortizacion.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> Delete(Amortizacion modelo)
        {
            try
            {
                Amortizacion amortizacion = await _dbContext.Amortizacion.FindAsync(modelo.IdAmortizacion);
                if (amortizacion == null)
                {
                    return false;
                }
                _dbContext.Amortizacion.Remove(amortizacion);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Amortizacion modelo)
        {
            try
            {
                Amortizacion amortizacion = await _dbContext.Amortizacion.FindAsync(modelo.IdAmortizacion);
                if (amortizacion == null)
                {
                    return false;
                }
                _dbContext.Amortizacion.Update(amortizacion);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
