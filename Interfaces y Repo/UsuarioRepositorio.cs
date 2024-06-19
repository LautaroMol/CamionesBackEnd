using API_Camiones.Data;
using API_Camiones.Interfaces;
using API_Camiones.Modelos;

namespace API_Camiones.Interfaces_y_Repo
{
    public class UsuarioRepositorio : IUsuario
    {
        private readonly ApplicationDbContext _dbContext;
        public UsuarioRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Usuario> GetId(int IdUsuario)
        {
            throw new NotImplementedException();
        }
        public Task<List<Usuario>> GetList()
        {
            throw new NotImplementedException();
        }
        public Task<Usuario> Add(Usuario modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Usuario modelo)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Update(Usuario modelo)
        {
            throw new NotImplementedException();
        }
    }
}
