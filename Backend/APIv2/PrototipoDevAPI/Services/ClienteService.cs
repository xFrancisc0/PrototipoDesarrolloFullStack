using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PrototipoDevAPI.DatabaseContext; // Asegúrate de tener la referencia al espacio de nombres del DbContext
using PrototipoDevAPI.Entities; // Asegúrate de tener la referencia al espacio de nombres de tus entidades
using System.Data;

namespace PrototipoDevAPI.Services
{
    public class ClienteService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public ClienteService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
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

        public async Task<List<ClienteSP>> GetClientesConSP()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetClientesConNombrePais", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<ClienteSP>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private ClienteSP MapToValue(SqlDataReader reader)
        {
            return new ClienteSP()
            {
                Id = (int)reader["Id"],
                DNI = reader["DNI"].ToString(),
                ClienteNombre = reader["ClienteNombre"].ToString(),
                ApellidoP = reader["ApellidoP"].ToString(),
                ApellidoM = reader["ApellidoM"].ToString(),
                PaisNombre = reader["PaisNombre"].ToString()
            };
        }



    }
}
