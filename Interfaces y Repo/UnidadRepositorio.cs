using API_Camiones.Data;
using API_Camiones.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Camiones.Interfaces_y_Repo
{
    public class UnidadRepositorio : IUnidad
    {
        private readonly ApplicationDbContext _dbContext;

        public UnidadRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unidad> GetId(int idUnidad)
        {
            Unidad unidad = await _dbContext.Unidades.FindAsync(idUnidad);
            return unidad;
        }

        public async Task<List<Unidad>> GetList()
        {
            List<Unidad> lista = await _dbContext.Unidades.ToListAsync();
            return lista;
        }

        public async Task<Unidad> Add(Unidad modelo)
        {
            await _dbContext.Unidades.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> Delete(Unidad modelo)
        {
            try
            {
                Unidad unidad = await _dbContext.Unidades.FindAsync(modelo.IdUnidad);
                if (unidad == null)
                {
                    return false;
                }
                _dbContext.Unidades.Remove(unidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Unidad modelo)
        {
            try
            {
                Unidad unidad = await _dbContext.Unidades.FindAsync(modelo.IdUnidad);
                if (unidad == null)
                {
                    return false;
                }
                _dbContext.Unidades.Update(unidad);
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
