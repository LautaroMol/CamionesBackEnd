using API_Camiones.Modelos;

namespace API_Camiones.Interfaces
{
    public interface IFactura
    {
        Task<List<Factura>> GetList();
        Task<Factura> GetId(int IdFactura);
        Task<Factura> Add(Factura modelo);
        Task<bool> Update(Factura modelo);
        Task<bool> Delete(Factura modelo);
    }
}
