using API_Camiones.Modelos;

namespace API_Camiones.Interfaces
{
    public interface IUsuario
    {
        Task<List<Usuario>> GetList();
        Task<Usuario> GetId(int IdUsuario);
        Task<Usuario> Add(Usuario modelo);
        Task<bool> Update(Usuario modelo);
        Task<bool> Delete(Usuario modelo);
    }
}
