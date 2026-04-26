using Application.Interfaces;
using Application.Orders;
using Application.Products;
using Application.Shipments;
using Infrastructure.Servicebus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Workers;

public static class IServiceCollectionExtensions
{
    public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterServiceBus(configuration);
    }

    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductHandler, ProductHandler>();
        services.AddScoped<IOrderHandler, OrderHandler>();
        services.AddScoped<IShipmentHandler, ShipmentHandler >();
    }
}
