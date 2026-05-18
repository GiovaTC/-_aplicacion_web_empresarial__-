using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Producto> Productos => Set<Producto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("PRODUCTOS");

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("ID");

                entity.Property(e => e.Nombre)
                .HasColumnName("NOMBRE");

                entity.Property(e => e.Precio)
                .HasColumnName("PRECIO");

                entity.Property(e => e.Stock)
                .HasColumnName("STOCK");
            });
        }
    }
}   
