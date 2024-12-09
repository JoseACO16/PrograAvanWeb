using Microsoft.EntityFrameworkCore;

namespace ProyectoPrograAvnzWeb.Models
{
    public class Db_Context_SYS : DbContext
    {
        public Db_Context_SYS(DbContextOptions<Db_Context_SYS> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Distrito> Distritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura explícitamente las relaciones
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Marca)
                .WithMany() // Si es relación uno a muchos, cambia según tu necesidad
                .HasForeignKey(p => p.IdMarca)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany() // Similar aquí
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
