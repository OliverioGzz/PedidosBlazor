using Blazored.Toast;
using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Components;
using PedidosBlazor.Data;
using PedidosBlazor.Services;
using PedidosBlazor.Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddBlazoredToast();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Pedidos.db"));

builder.Services.AddScoped<IPlatilloService, PlatilloService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IMesaService, MesaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PedidosBlazor.Client._Imports).Assembly);

app.Run();
