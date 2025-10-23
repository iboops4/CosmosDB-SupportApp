using CosmoooDB.Components;
using CosmoooDB.Services;

var builder = WebApplication.CreateBuilder(args);

// Tilføj CosmosService som Singleton
builder.Services.AddSingleton(sp =>
{
    var connectionString = builder.Configuration["CosmosDb:ConnectionString"];
    var databaseName = builder.Configuration["CosmosDb:DatabaseName"];
    var containerName = builder.Configuration["CosmosDb:ContainerName"];

    return new CosmosService(connectionString!, databaseName!, containerName!);
});

// Standard Blazor-opsætning
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// HTTP-pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// 🧩 Antiforgery SKAL være her (lige før MapRazorComponents)
app.UseRouting();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
