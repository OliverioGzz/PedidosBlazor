using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Data;
using PedidosBlazor.Shared.Interfaces;
using PedidosBlazor.Shared.Models;

namespace PedidosBlazor.Services;
public class MesaService : IMesaService
{
    private readonly AppDbContext _context;

    public MesaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Mesa>> ObtenerTodasAsync()
    {
        return await _context.Mesas.ToListAsync();
    }

    public async Task<Mesa?> ObtenerPorIdAsync(int id)
    {
        return await _context.Mesas.FindAsync(id);
    }

    public async Task<int> ActualizarAsync(Mesa mesa)
    {
        _context.Mesas.Update(mesa);
        return await _context.SaveChangesAsync();
    }
}

