using API_Camiones.Modelos;

namespace API_Camiones.Interfaces
{
    public interface IGasto
    {
        Task<List<Gasto>> GetList();
        Task<Gasto> GetId(int IdGasto);
        Task<Gasto> Add(Gasto modelo);
        Task<bool> Update(Gasto modelo);
        Task<bool> Delete(Gasto modelo);
    }
}
