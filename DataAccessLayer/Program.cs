using InfrastructureLayer;
using InfrastructureLayer.Data;
using DataAccessLayer.Interfaces;
using InfrastructureLayer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// register DbContext from InfrastructureLayer
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnectionString"));
});

// register repositories (interfaces remain in DataAccessLayer.Interfaces)
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();

var app = builder.Build();

app.MapControllers();

// seed data (optional)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    var seed = new Seed(context);
    seed.SeedDataContext();
}

app.Run();