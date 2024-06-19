using API_Camiones.Data;
using API_Camiones.Interfaces;
using API_Camiones.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API_Camiones.Interfaces_y_Repo
{
    public class ClienteRepositorio : ICliente
    {
        private readonly ApplicationDbContext _dbContext;
        public ClienteRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Cliente> GetId(int IdCliente)
        {
            Cliente cliente = await _dbContext.Clientes.FindAsync(IdCliente);
            return cliente;
        }

        public async Task<List<Cliente>> GetList()
        {
            return await _dbContext.Clientes.ToListAsync();
        }
        public async Task<Cliente> Add(Cliente modelo)
        {
            await _dbContext.Clientes.AddAsync(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> Delete(Cliente modelo)
        {
            try
            {
                Cliente cliente = await _dbContext.Clientes.FindAsync(modelo.Idcliente);
                if (cliente == null)
                {
                    return false;
                }
                _dbContext.Clientes.Remove(cliente);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch { return false; }
        }
        public async Task<bool> Update(Cliente modelo)
        {
            try
            {
                Cliente cliente = await _dbContext.Clientes.FindAsync(modelo.Idcliente);
                if (cliente == null)
                {
                    return false;
                }
                _dbContext.Clientes.Update(cliente);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
