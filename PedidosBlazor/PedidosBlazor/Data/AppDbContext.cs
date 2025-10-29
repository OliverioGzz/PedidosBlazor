using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Shared.Models;

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
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Mesa)
            .WithMany(m => m.Pedidos)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Empleado)
            .WithMany(e => e.Pedidos)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ItemPedido>()
            .HasOne(i => i.Platillo)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ItemPedido>()
            .HasOne<Pedido>()
            .WithMany(p => p.Items)
            .HasForeignKey(i => i.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>().HasData(
            new Empleado { Id = 1, Nombre = "Juan Pérez" }
        );

        modelBuilder.Entity<Mesa>().HasData(
            new Mesa { Id = 1, Numero = 1, Estado = "Disponible" },
            new Mesa { Id = 2, Numero = 2, Estado = "Disponible" },
            new Mesa { Id = 3, Numero = 3, Estado = "Disponible" }
        );

        modelBuilder.Entity<Platillo>().HasData(
            new Platillo { Id = 1, Nombre = "Tacos", Precio = 45.00m },
            new Platillo { Id = 2, Nombre = "Quesadillas", Precio = 35.00m }
        );
    }
}
