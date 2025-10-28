using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PedidosBlazor.Client.Services;
using PedidosBlazor.Shared.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IPlatilloService, PlatilloHttpService>();
builder.Services.AddScoped<IMesaService, MesaHttpService>();
builder.Services.AddScoped<IPedidoService, PedidoHttpService>();

builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
