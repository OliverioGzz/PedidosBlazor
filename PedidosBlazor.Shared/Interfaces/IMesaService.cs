using PedidosBlazor.Shared.Models;

namespace PedidosBlazor.Shared.Interfaces;
public interface IMesaService
{
    Task<List<Mesa>> ObtenerTodasAsync();
    Task<Mesa?> ObtenerPorIdAsync(int id);
    Task ActualizarAsync(Mesa mesa);
}