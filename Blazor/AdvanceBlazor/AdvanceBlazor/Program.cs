using AdvanceBlazor.Client.Pages;
using AdvanceBlazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts(); // Enforces HTTPS in production
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseStaticFiles();      // Serve static files

app.UseAntiforgery();      // Enable antiforgery protection

// Configure component routing
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(AdvanceBlazor.Client._Imports).Assembly);

app.Run();
