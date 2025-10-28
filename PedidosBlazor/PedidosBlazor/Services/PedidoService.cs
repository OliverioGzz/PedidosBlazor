using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Data;
using PedidosBlazor.Shared.Interfaces;
using PedidosBlazor.Shared.Models;

namespace PedidosBlazor.Services;

public class PedidoService : IPedidoService
{
    private readonly AppDbContext _context;

    public PedidoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pedido>> ObtenerTodosAsync()
    {
        return await _context.Pedidos
            .Include(p => p.Mesa)
            .Include(p => p.Empleado)
            .Include(p => p.Items)
            .ThenInclude(i => i.Platillo)
            .ToListAsync();
    }

    public async Task<Pedido?> ObtenerPorIdAsync(int id)
    {
        return await _context.Pedidos
            .Include(p => p.Mesa)
            .Include(p => p.Empleado)
            .Include(p => p.Items)
            .ThenInclude(i => i.Platillo)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Pedido>> ObtenerPorMesaYEstadoAsync(int? mesaId, string? estado)
    {
        var query = _context.Pedidos
            .Include(p => p.Mesa)
            .Include(p => p.Empleado)
            .AsQueryable();

        if (mesaId.HasValue)
            query = query.Where(p => p.MesaId == mesaId.Value);

        if (!string.IsNullOrEmpty(estado))
            query = query.Where(p => p.Estado == estado);

        return await query.OrderByDescending(p => p.Fecha).ToListAsync();
    }

    public async Task<List<ItemPedido>> ObtenerItemsPorPedidoIdAsync(int pedidoId)
    {
        return await _context.ItemsPedido
            .Include(i => i.Platillo)
            .Where(i => i.PedidoId == pedidoId)
            .ToListAsync();
    }

    public async Task<Pedido> CrearAsync(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<int> ActualizarAsync(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        return await _context.SaveChangesAsync();
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido == null) return false;

        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();
        return true;
    }
}
