using cp2.Domain.Entity;
using cp2.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace cp2.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Moto> Motos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new MotoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
