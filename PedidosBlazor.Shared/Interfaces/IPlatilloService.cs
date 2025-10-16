using PedidosBlazor.Shared.Models;

namespace PedidosBlazor.Shared.Interfaces;
public interface IPlatilloService
{
    Task<List<Platillo>> ObtenerTodosAsync();
}
