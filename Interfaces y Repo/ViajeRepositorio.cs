using API_Camiones.Data;
using API_Camiones.Interfaces;
using API_Camiones.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API_Camiones.Interfaces_y_Repo
{
    public class ViajeRepositorio : IViaje
    {
        private readonly ApplicationDbContext _dbContext;
        public ViajeRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Viaje> GetId(int IdViaje)
        {
            Viaje viaje = await _dbContext.Viajes.FindAsync(IdViaje);
            return viaje;
        }

        public async Task<List<Viaje>> GetList()
        {
            return await _dbContext.Viajes.ToListAsync();
        }
        public async Task<Viaje> Add(Viaje modelo)
        {
            await _dbContext.Viajes.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> Delete(Viaje modelo)
        {
            try
            {
                Viaje viaje = await _dbContext.Viajes.FindAsync(modelo.Idviaje);
                if (viaje == null)
                {
                    return false;
                }
                _dbContext.Remove(viaje);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public async Task<bool> Update(Viaje modelo)
        {
            try
            {
                Viaje viaje = await _dbContext.Viajes.FindAsync(modelo.Idviaje);
                if (viaje == null)
                {
                    return false;
                }
                _dbContext.Update(viaje);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
