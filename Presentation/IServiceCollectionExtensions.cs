using Application2.Orders;
using Application2.Products;
using Application2.Shipments;
using Domain2.Interfaces;
using Infrastructure.Databases;
using Infrastructure.Databases.Repositories;
using Infrastructure.Servicebus;

namespace WebApi;

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
