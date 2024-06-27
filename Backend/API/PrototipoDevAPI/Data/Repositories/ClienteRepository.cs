using Microsoft.EntityFrameworkCore;
using PrototipoDevAPI.Data.DbContexts;
using PrototipoDevAPI.Data.Models;
using PrototipoDevAPI.Data.DbContexts;
using PrototipoDevAPI.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoDevAPI.Data.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly AppDbContext _dbContext;

        public ClientesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cliente>> GetClientesPaginadosAsync(int pageNumber, int pageSize)
        {
            return await _dbContext.Clientes
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
