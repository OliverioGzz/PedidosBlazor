using PedidosBlazor.Shared.Interfaces;
using PedidosBlazor.Shared.Models;
using System.Net.Http.Json;

namespace PedidosBlazor.Client.Services
{
    public class MesaHttpService : IMesaService
    {
        private readonly HttpClient _http;

        public MesaHttpService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Mesa>> ObtenerTodasAsync()
        {
            return await _http.GetFromJsonAsync<List<Mesa>>("api/mesas") ?? new List<Mesa>();
        }

        public async Task<Mesa?> ObtenerPorIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Mesa>($"api/mesas/{id}");
        }

        public async Task<Mesa> CrearAsync(Mesa mesa)
        {
            var response = await _http.PostAsJsonAsync("api/mesas", mesa);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Mesa>()!;
        }

        public async Task<int> ActualizarAsync(Mesa mesa)
        {
            var response = await _http.PutAsJsonAsync($"api/mesas/{mesa.Id}", mesa);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>()!;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/mesas/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
