using Application.Interfaces;
using Application.Orders;
using Application.Orders.Commands;
using Application.Orders.Queries;
using Application.Products;
using Application.Products.Commands;
using Application.Products.Queries;
using Application.Shipments;
using Application.Shipments.Commands;
using Application.Shipments.Queries;
using Domain;
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
        services.AddScoped<ICommandHandler<CreateProductCommand, int>, CreateProductHandler>();
        services.AddScoped<ICommandHandler<UpdateProductCommand>, UpdateProductHandler>();
        services.AddScoped<ICommandHandler<DeleteProductCommand>, DeleteProductHandler>();
        services.AddScoped<IQueryHandler<GetSingleProductQuery, Product>, GetSingleProductHandler>();
        services.AddScoped<IQueryHandler<GetAllProductsQuery, ICollection<Product>>, GetAllProductsHandler>();
        services.AddScoped<ICommandHandler<CreateOrderCommand, int>, CreateOrderHandler>();
        services.AddScoped<ICommandHandler<UpdateOrderCommand>, UpdateOrderHandler>();
        services.AddScoped<ICommandHandler<DeleteOrderCommand>, DeleteOrderHandler>();
        services.AddScoped<IQueryHandler<GetSingleOrderQuery, Order>, GetSingleOrderHandler>();
        services.AddScoped<IQueryHandler<GetAllOrdersQuery, ICollection<Order>>, GetAllOrdersHandler>();
        services.AddScoped<ICommandHandler<CreateShipmentCommand, int>, CreateShipmentHandler>();
        services.AddScoped<ICommandHandler<UpdateShipmentCommand>, UpdateShipmentHandler>();
        services.AddScoped<ICommandHandler<DeleteShipmentCommand>, DeleteShipmentHandler>();
        services.AddScoped<IQueryHandler<GetSingleShipmentQuery, Shipment>, GetSingleShipmentHandler>();
        services.AddScoped<IQueryHandler<GetAllShipmentsQuery, ICollection<Shipment>>, GetAllShipmentsHandler>();
    }
}