using Azure;
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
        private readonly string _connectionString;

        public ClienteService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection"); ;
        }

        //Obtener clientes por LINQ
        public async Task<Resultado> GetClientesConLINQ()
        {
            var response = await _dbContext.Clientes
                .Include(c => c.Pais) // Incluir la relación con la tabla Paises
                .Select(c => new ClienteOutput
                {
                    Id = c.Id,
                    DNI = c.DNI,
                    ClienteNombre = c.Nombre,
                    ApellidoP = c.ApellidoP,
                    ApellidoM = c.ApellidoM,
                    PaisNombre = c.Pais.Nombre
                })
                .ToListAsync();

            var resultado = new Resultado();

            if (response != null && response.Count > 0)
            {
                resultado.ok = true;
                resultado.id = 0;
                resultado.data = new { datos = response, total = 0 }; ;
                resultado.mensaje = "OK";
            }
            else
            {
                resultado.ok = false;
                resultado.id = 0;
                resultado.mensaje = "No hay resultados disponibles.";
            }

            return resultado;
        }

        public async Task<Resultado> GetClientesConSP()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetClientesConNombrePais", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<ClienteOutput>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    var resultado = new Resultado();

                    if (response != null && response.Count > 0)
                    {
                        resultado.ok = true;
                        resultado.id = 0;
                        resultado.data = new { datos = response, total = 0 }; ;
                        resultado.mensaje = "OK";
                    }
                    else
                    {
                        resultado.ok = false;
                        resultado.id = 0;
                        resultado.mensaje = "No hay resultados disponibles."; 
                    }

                    return resultado;
                }
            }
        }

        private ClienteOutput MapToValue(SqlDataReader reader)
        {
            return new ClienteOutput()
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
