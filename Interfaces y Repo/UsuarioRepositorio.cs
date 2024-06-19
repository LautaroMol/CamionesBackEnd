using API_Camiones.Data;
using API_Camiones.Interfaces;
using API_Camiones.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API_Camiones.Interfaces_y_Repo
{
    public class UsuarioRepositorio : IUsuario
    {
        private readonly ApplicationDbContext _dbContext;
        public UsuarioRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Usuario> GetId(int IdUsuario)
        {
            Usuario usuario = await _dbContext.Usuarios.FindAsync(IdUsuario);
            return usuario;
        }
        public async Task<List<Usuario>> GetList()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<Usuario> Add(Usuario modelo)
        {
            await _dbContext.Usuarios.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> Delete(Usuario modelo)
        {
            try
            {
                Usuario usuario = await _dbContext.Usuarios.FindAsync(modelo.Idusuario);
                if (usuario == null)
                {
                    return false;
                }
                _dbContext.Remove(usuario);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public async Task<bool> Update(Usuario modelo)
        {
            try
            {
                Usuario usuario = await _dbContext.Usuarios.FindAsync(modelo.Idusuario);
                if (usuario == null)
                {
                    return false;
                }
                _dbContext.Update(usuario);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
