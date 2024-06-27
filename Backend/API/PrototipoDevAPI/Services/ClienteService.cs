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

        //Obtener clientes por LINQ
        public async Task<List<Cliente>> GetClientesConLINQ()
        {
            var clientes = await _dbContext.Clientes
                .Include(c => c.Pais) // Incluir la relación con la tabla Paises
                .Select(c => new Cliente
                {
                    Id = c.Id,
                    DNI = c.DNI,
                    Nombre = c.Nombre,
                    ApellidoP = c.ApellidoP,
                    ApellidoM = c.ApellidoM,
                    PaisId = c.PaisId,
                    Pais = new Pais // Proyección de la entidad Pais
                    {
                        Id = c.Pais.Id,
                        Nombre = c.Pais.Nombre
                    }
                })
                .ToListAsync();

            return clientes;
        }

        //Obtener clientes por SP
        public async Task<List<Cliente>> GetClientesConSP()
        {
            // Llamada al Stored Procedure desde EF Core
            var clientes = await _dbContext.Clientes.FromSqlRaw("EXEC SP_GetClientesConNombrePais").ToListAsync();

            return clientes;
        }
    }
}
