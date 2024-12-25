using CRUDWithBlazor.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using CRUDWithBlazor.Data;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register QuickGrid and DbContext
//builder.Services.AddQuickGrid();  // Make sure to include QuickGrid package in your project
builder.Services.AddDbContextFactory<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

// Optional: Add support for protected browser storage
builder.Services.AddSingleton<ProtectedSessionStorage>();

// Add Razor components for server-side Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // Optional depending on your requirements

// Ensure database developer exception filter is added for development mode
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
}

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Map Razor components for Blazor app
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
