using PedidosBlazor.Shared.Models;

namespace PedidosBlazor.Shared.Interfaces
{
    public interface IPedidoService
    {
        Task<List<Pedido>> ObtenerTodosAsync();
        Task<Pedido?> ObtenerPorIdAsync(int id);
        Task<List<Pedido>> ObtenerPorMesaYEstadoAsync(int? mesaId, string? estado);
        Task<List<ItemPedido>> ObtenerItemsPorPedidoIdAsync(int pedidoId);
        Task<Pedido> CrearAsync(Pedido pedido);
        Task<int> ActualizarAsync(Pedido pedido);
        Task<bool> EliminarAsync(int id);
    }

}
