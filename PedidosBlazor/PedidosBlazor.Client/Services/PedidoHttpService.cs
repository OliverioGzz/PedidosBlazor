using PedidosBlazor.Shared.Interfaces;
using PedidosBlazor.Shared.Models;
using System.Net.Http.Json;

namespace PedidosBlazor.Client.Services
{
    public class PedidoHttpService : IPedidoService
    {
        private readonly HttpClient _http;

        public PedidoHttpService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Pedido>> ObtenerTodosAsync()
        {
            return await _http.GetFromJsonAsync<List<Pedido>>("api/pedidoes") ?? new List<Pedido>();
        }

        public async Task<Pedido?> ObtenerPorIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Pedido>($"api/pedidoes/{id}");
        }

        public async Task<List<Pedido>> ObtenerPorMesaYEstadoAsync(int? mesaId, string? estado)
        {
            return await _http.GetFromJsonAsync<List<Pedido>>($"api/pedidoes/mesa/{mesaId}/estado/{estado}") ?? new List<Pedido>();
        }

        public async Task<List<ItemPedido>> ObtenerItemsPorPedidoIdAsync(int pedidoId)
        {
            return await _http.GetFromJsonAsync<List<ItemPedido>>($"api/pedidoes/{pedidoId}/items") ?? new List<ItemPedido>();
        }

        public async Task<Pedido> CrearAsync(Pedido pedido)
        {
            var response = await _http.PostAsJsonAsync("api/pedidoes", pedido);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Pedido>()!;
        }

        public async Task<int> ActualizarAsync(Pedido pedido)
        {
            var response = await _http.PutAsJsonAsync($"api/pedidoes/{pedido.Id}", pedido);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>()!;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/pedidoes/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
