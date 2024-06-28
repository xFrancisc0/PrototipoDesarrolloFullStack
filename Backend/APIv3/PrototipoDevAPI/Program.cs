using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PrototipoDevAPI.DatabaseContext;
using PrototipoDevAPI.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        // Aquí puedes acceder al servicio de ClienteService
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                // Obtener el contexto de la base de datos
                var dbContext = services.GetRequiredService<AppDbContext>();

                // Aplicar migraciones (si es necesario)
                dbContext.Database.EnsureCreated(); // O dbContext.Database.Migrate();

                // Obtener el servicio de ClienteService
                var clienteService = services.GetRequiredService<ClienteService>();

                // Aquí puedes utilizar clienteService según tus necesidades
                // Por ejemplo:
                //var clientes = clienteService.GetClientesConLINQ().Result;
                /*foreach (var cliente in clientes)
                {
                    Console.WriteLine($"{cliente.Id}: {cliente.Nombre} {cliente.Apellido}");
                }*/
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Ocurrió un error durante la configuración.");
            }
        }

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>(); // Si tuvieras un Startup.cs
            });
}
