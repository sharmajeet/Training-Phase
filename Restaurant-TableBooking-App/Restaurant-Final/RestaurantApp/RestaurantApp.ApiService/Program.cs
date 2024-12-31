using Microsoft.EntityFrameworkCore;
using Restaurant_BL.Repositories;
using Restaurant_BL.Services;
using Restaurant_Database.Data;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
//for tables
builder.Services.AddScoped<ITableServices , TableService>();
builder.Services.AddScoped<ITableRepository , TableRepository>();
//for bookings
builder.Services.AddScoped<IBookingRepository , BookingRepository>();
builder.Services.AddScoped<IBookingService , BookingService>();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapDefaultEndpoints();

app.Run();
