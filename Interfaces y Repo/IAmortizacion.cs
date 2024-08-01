using API_Camiones.Modelos;

namespace API_Camiones.Interfaces_y_Repo
{
    public interface IAmortizacion
    {
        Task<List<Amortizacion>> GetList();
        Task<Amortizacion> GetId(int idAmortizacion);
        Task<Amortizacion> Add(Amortizacion modelo);
        Task<bool> Update(Amortizacion modelo);
        Task<bool> Delete(Amortizacion modelo);
    }
}
