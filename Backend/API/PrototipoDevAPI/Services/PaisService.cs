using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrototipoDevAPI.DatabaseContext;
using PrototipoDevAPI.Entities;

namespace PrototipoDevAPI.Services
{
    public class PaisService
    {
        private readonly AppDbContext _dbContext;

        public PaisService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Pais>> GetPaisesPaginadosConEFCoreAsync(int pageNumber, int pageSize)
        {
            return await _dbContext.Paises.ToListAsync();
        }

        // Otros métodos relacionados con países
    }
}
