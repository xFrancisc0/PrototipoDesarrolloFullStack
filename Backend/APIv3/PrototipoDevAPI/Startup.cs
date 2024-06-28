using PrototipoDevAPI.DatabaseContext;
using PrototipoDevAPI.Services;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Este método es llamado por el runtime. Aquí se configuran los servicios.
    public void ConfigureServices(IServiceCollection services)
    {
        // Configurar DbContext (Ejemplo con SQL Server)
        IServiceCollection serviceCollection = services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
        ));


        // Registrar ClienteService
        services.AddScoped<ClienteService>();

        // Otros servicios y configuraciones
        services.AddControllers();
    }

    // Este método es llamado por el runtime. Aquí se configura el pipeline de solicitud HTTP.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage(); // Página de error detallada en entorno de desarrollo
        }
        else
        {
            app.UseExceptionHandler("/Error"); // Manejo de errores en otros entornos
            app.UseHsts();
        }

        app.UseHttpsRedirection(); // Redireccionamiento HTTP a HTTPS
        app.UseRouting(); // Habilitar enrutamiento

        app.UseAuthorization(); // Middleware de autorización

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Habilitar controladores MVC
        });
    }
}
