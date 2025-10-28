using PedidosBlazor.Shared.Interfaces;
using PedidosBlazor.Shared.Models;
using System.Net.Http.Json;

namespace PedidosBlazor.Client.Services
{
    public class PlatilloHttpService : IPlatilloService
    {
        private readonly HttpClient _http;

        public PlatilloHttpService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Platillo>> ObtenerTodosAsync()
        {
            return await _http.GetFromJsonAsync<List<Platillo>>("api/platilloes") ?? new List<Platillo>();
        }

        public async Task<Platillo?> ObtenerPorIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Platillo>($"api/platilloes/{id}");
        }

        public async Task<Platillo> CrearAsync(Platillo platillo)
        {
            var response = await _http.PostAsJsonAsync("api/platilloes", platillo);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Platillo>()!;
        }

        public async Task<Platillo> ActualizarAsync(Platillo platillo)
        {
            var response = await _http.PutAsJsonAsync($"api/platilloes/{platillo.Id}", platillo);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Platillo>()!;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/platilloes/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
