using GestionApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionApp.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVentas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Configuración de PRODUCTO
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(p => p.Id); // Clave primaria
                entity.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Precio).HasColumnType("decimal(18,2)"); // Precisión para dinero

                // Relación: Un Producto pertenece a una Categoría
                entity.HasOne(p => p.Categoria)
                      .WithMany(c => c.Productos)
                      .HasForeignKey(p => p.CategoriaId)
                      .OnDelete(DeleteBehavior.Restrict); // Si borro categoría, no borro productos
            });

            // 2. Configuración de VENTA
            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Total).HasColumnType("decimal(18,2)");
                entity.Property(v => v.Fecha).HasDefaultValueSql("GETDATE()"); // Azure pone la fecha sola

                // Relación con Usuario (Vendedor)
                entity.HasOne(v => v.Usuario)
                      .WithMany(u => u.Ventas)
                      .HasForeignKey(v => v.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relación con Cliente
                entity.HasOne(v => v.Cliente)
                      .WithMany(c => c.Compras)
                      .HasForeignKey(v => v.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 3. Configuración de DETALLE VENTA
            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(dv => dv.Id);
                entity.Property(dv => dv.PrecioUnitario).HasColumnType("decimal(18,2)");

                // Relación con la Venta padre
                entity.HasOne(dv => dv.Venta)
                      .WithMany(v => v.Detalles)
                      .HasForeignKey(dv => dv.VentaId);
            });

            // 4. Configuración de USUARIO (Login)
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(u => u.NombreUsuario).IsUnique(); // No puede haber dos iguales en producción
                entity.Property(u => u.NombreUsuario).IsRequired().HasMaxLength(50);
            });

            // 5. Configuración de CLIENTE
            modelBuilder.Entity<Cliente>(entity => {
                entity.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Dni).HasMaxLength(20);
            });
        }

    }
}
