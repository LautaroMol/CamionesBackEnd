using API_Camiones.Modelos;

namespace API_Camiones.Interfaces
{
    public interface ICategoria
    {
        Task<List<Categoria>> GetList();
        Task<Categoria> GetId(int IdCategoria);
        Task<Categoria> Add(Categoria modelo);
        Task<bool> Update(Categoria modelo);
        Task<bool> Delete(Categoria modelo);
    }
}
