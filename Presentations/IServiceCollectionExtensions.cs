using Application.Interfaces;
using Application.Orders;
using Application.Products;
using Application.Shipments;
using Infrastructure.Databases;
using Infrastructure.Servicebus;

namespace Presentation;

public static class IServiceCollectionExtensions
{
    public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterDatabaseRepositories(configuration);
        services.RegisterServiceBus(configuration);
    }

    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductHandler, ProductHandler>();
        services.AddScoped<IOrderHandler, OrderHandler>();
        services.AddScoped<IShipmentHandler, ShipmentHandler >();
    }
}
