using Blazored.Toast;
using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Components;
using PedidosBlazor.Data;
using PedidosBlazor.Services;
using PedidosBlazor.Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddBlazoredToast();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Pedidos.db"));

builder.Services.AddScoped<IPlatilloService, PlatilloService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IMesaService, MesaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MiCors", policy =>
    {
        policy.WithOrigins(
            "https://localhost:7279",
            "http://localhost:5278"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseCors("MiCors");
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PedidosBlazor.Client._Imports).Assembly);

app.Run();
