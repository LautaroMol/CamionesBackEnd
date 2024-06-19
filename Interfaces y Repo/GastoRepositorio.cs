using API_Camiones.Data;
using API_Camiones.Interfaces;
using API_Camiones.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API_Camiones.Interfaces_y_Repo
{
    public class GastoRepositorio : IGasto
    {
        private readonly ApplicationDbContext _dbContext;
        public GastoRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Gasto> GetId(int IdGasto)
        {
            Gasto gasto = await _dbContext.Gastos.FindAsync(IdGasto);
            return gasto;
        }
        public async Task<List<Gasto>> GetList()
        {
            return await _dbContext.Gastos.ToListAsync();
        }
        public async Task<Gasto> Add(Gasto modelo)
        {
            await _dbContext.Gastos.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
        public async Task<bool> Delete(Gasto modelo)
        {
            try
            {
                Gasto gasto = await _dbContext.Gastos.FindAsync(modelo.Idgasto);
                if (gasto == null)
                {
                    return false;
                }
                _dbContext.Remove(gasto);
                await _dbContext.SaveChangesAsync();
                return true;
            }catch { return false; }
        }                
        public async Task<bool> Update(Gasto modelo)
        {
            try
            {
                Gasto gasto = await _dbContext.Gastos.FindAsync(modelo.Idgasto);
                if (gasto == null)
                {
                    return false;
                }
                _dbContext.Update(gasto);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
