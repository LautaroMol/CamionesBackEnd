using API_Camiones.Modelos;

namespace API_Camiones.Interfaces
{
    public interface IViaje
    {
        Task<List<Viaje>> GetList();
        Task<Viaje> GetId(int IdViaje);
        Task<Viaje> Add(Viaje modelo);
        Task<bool> Update(Viaje modelo);
        Task<bool> Delete(Viaje modelo);
    }
}
