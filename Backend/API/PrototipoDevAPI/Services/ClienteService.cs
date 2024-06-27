using Microsoft.EntityFrameworkCore;
using PrototipoDevAPI.DatabaseContext;
using PrototipoDevAPI.Entities;

namespace PrototipoDevAPI.Services
{
    public class ClienteService
    {
        private readonly AppDbContext _dbContext;

        public ClienteService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cliente>> GetClientesPaginadosConEFCoreAsync(int pageNumber, int pageSize)
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        // Otros métodos relacionados con clientes
    }
}
