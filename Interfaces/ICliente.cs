using API_Camiones.Modelos;

namespace API_Camiones.Interfaces
{
    public interface ICliente
    {
        Task<List<Cliente>> GetList();
        Task<Cliente> GetId(int IdCliente);
        Task<Cliente> Add(Cliente modelo);
        Task<bool> Update(Cliente modelo);
        Task<bool> Delete(Cliente modelo);
    }
}
