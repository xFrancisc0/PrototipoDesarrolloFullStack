using Microsoft.EntityFrameworkCore;
using PrototipoDevAPI.Entities;

namespace PrototipoDevAPI.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Continente> Continentes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones adicionales de tu modelo
        }
    }
}
