using Microsoft.EntityFrameworkCore;
using FerreteriaValdiviaNueva.Models;

namespace FerreteriaValdiviaNueva.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Proveedor> Proveedores { get; set; } = null!;
        public DbSet<Rol> Roles { get; set; } = null!;
        public DbSet<Empleado> Empleados { get; set; } = null!;
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Caja> Cajas { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones adicionales o restricciones de mapeo si son necesarias
            modelBuilder.Entity<Producto>()
                .Property(p => p.PrecioVenta)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Caja>()
                .Property(c => c.MontoInicial)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Caja>()
                .Property(c => c.MontoFinal)
                .HasPrecision(18, 2);
        }
    }
}