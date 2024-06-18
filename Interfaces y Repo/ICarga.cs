using API_Camiones.Modelos;

namespace API_Camiones.DTOs
{
    public interface ICarga
    {
        Task<List<Carga>> GetList();
        Task<Carga> GetId(int IdCarga);
        Task<Carga> Add(Carga modelo);
        Task<bool> Update(Carga modelo);
        Task<bool> Delete(Carga modelo);
    }
}
