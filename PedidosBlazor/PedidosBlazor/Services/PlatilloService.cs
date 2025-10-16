using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Data;
using PedidosBlazor.Shared.Interfaces;
using PedidosBlazor.Shared.Models;

namespace PedidosBlazor.Services
{
    public class PlatilloService : IPlatilloService
    {
        private readonly AppDbContext _context;

        public PlatilloService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Platillo>> ObtenerTodosAsync()
        {
            return await _context.Platillos.ToListAsync();
        }
    }
}


