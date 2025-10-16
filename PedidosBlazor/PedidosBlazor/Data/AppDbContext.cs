using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Shared.Models;
using System;

namespace PedidosBlazor.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Mesa> Mesas => Set<Mesa>();
    public DbSet<Empleado> Empleados => Set<Empleado>();
    public DbSet<Platillo> Platillos => Set<Platillo>();
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<ItemPedido> ItemsPedido => Set<ItemPedido>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar Mesa
        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasIndex(m => m.Numero).IsUnique();
            entity.Property(m => m.Estado)
                  .HasConversion<string>()
                  .HasDefaultValue("Libre");
        });

        // Configurar Pedido
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.Property(p => p.Estado)
                  .HasConversion<string>()
                  .HasDefaultValue("Pendiente");

            entity.HasOne(p => p.Mesa)
                  .WithMany()
                  .HasForeignKey(p => p.MesaId);

            entity.HasOne(p => p.Empleado)
                  .WithMany()
                  .HasForeignKey(p => p.EmpleadoId);
        });

        // Configurar ItemPedido
        modelBuilder.Entity<ItemPedido>(entity =>
        {
            entity.HasOne(ip => ip.Pedido)
                  .WithMany(p => p.Items)
                  .HasForeignKey(ip => ip.PedidoId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ip => ip.Platillo)
                  .WithMany()
                  .HasForeignKey(ip => ip.PlatilloId);
        });

        // Datos iniciales
        modelBuilder.Entity<Empleado>().HasData(
            new Empleado { Id = 1, Nombre = "Mesero Principal", Rol = "Mesero" }
        );

        modelBuilder.Entity<Platillo>().HasData(
            new Platillo { Id = 1, Nombre = "Hamburguesa", Precio = 8.99m },
            new Platillo { Id = 2, Nombre = "Pizza", Precio = 12.50m },
            new Platillo { Id = 3, Nombre = "Ensalada", Precio = 6.75m },
            new Platillo { Id = 4, Nombre = "Sopa", Precio = 4.50m }
        );

        modelBuilder.Entity<Mesa>().HasData(
            new Mesa { Id = 1, Numero = 1, Estado = "Libre" },
            new Mesa { Id = 2, Numero = 2, Estado = "Libre" },
            new Mesa { Id = 3, Numero = 3, Estado = "Libre" },
            new Mesa { Id = 4, Numero = 4, Estado = "Libre" },
            new Mesa { Id = 5, Numero = 5, Estado = "Libre" }
        );
    }
}
