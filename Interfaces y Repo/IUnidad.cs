using API_Camiones.Modelos;

namespace API_Camiones.Interfaces_y_Repo
{
    public interface IUnidad
    {
        Task<List<Unidad>> GetList();
        Task<Unidad> GetId(int idUnidad);
        Task<Unidad> Add(Unidad modelo);
        Task<bool> Update(Unidad modelo);
        Task<bool> Delete(Unidad modelo);
    }
}
