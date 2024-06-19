using API_Camiones.Data;
using API_Camiones.DTOs;
using API_Camiones.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API_Camiones.Interfaces_y_Repo
{
    public class CargaRepositorio : ICarga
    {
        private readonly ApplicationDbContext _dbContext;
        
        public CargaRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Carga> GetId(int IdCarga)
        {
            Carga carga = await _dbContext.Cargas.FindAsync(IdCarga);
            return carga;
        }

        public async Task<List<Carga>> GetList()
        {
            List<Carga> lista = await _dbContext.Cargas.ToListAsync();
            return lista;
        }
        public async Task<Carga> Add(Carga modelo)
        {
            await _dbContext.Cargas.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> Delete(Carga modelo)
        {
            try
            {
                Carga carga = await _dbContext.Cargas.FindAsync(modelo.Idcarga);
                if (carga == null)
                {
                    return false;
                }
                _dbContext.Cargas.Remove(carga);
                await _dbContext.SaveChangesAsync();
                return true;

            }catch { return false; }
        }

        public async Task<bool> Update(Carga modelo)
        {
            try
            {
                Carga carga = await _dbContext.Cargas.FindAsync(modelo.Idcarga);
                if (carga == null)
                {
                    return false;
                }
                _dbContext.Cargas.Update(carga);
                await _dbContext.SaveChangesAsync();
                return true;
            }catch { return false; }
        }
    }
}
