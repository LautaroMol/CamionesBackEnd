using API_Camiones.Data;
using API_Camiones.Interfaces;
using API_Camiones.Modelos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API_Camiones.Interfaces_y_Repo
{
    public class CategoriaRepositorio : ICategoria
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoriaRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Categoria> GetId(int IdCategoria)
        {
            Categoria categoria = await _dbContext.Categorias.FindAsync(IdCategoria);
            return categoria;
        }

        public async Task<List<Categoria>> GetList()
        {
            return await _dbContext.Categorias.ToListAsync();
        }
        public async Task<Categoria> Add(Categoria modelo)
        {
            await _dbContext.Categorias.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> Delete(Categoria modelo)
        {
            try
            {
                Categoria categoria = await _dbContext.Categorias.FindAsync(modelo.Idcategoria);
                if (categoria == null)
                {
                    return false;
                }
                _dbContext.Categorias.Remove(categoria);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch { return false; }
        }

        public async Task<bool> Update(Categoria modelo)
        {
            try
            {
                Categoria categoria = await _dbContext.Categorias.FindAsync(modelo.Idcategoria);
                if (categoria == null)
                {
                    return false;
                }
                _dbContext.Categorias.Update(categoria);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
