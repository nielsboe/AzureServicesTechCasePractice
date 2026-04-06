using Domain2.Interfaces;
using Infrastructure.Databases.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Databases;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterDatabaseRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));
        var config = configuration.GetRequiredSection(DatabaseOptions.SectionName).Get<DatabaseOptions>();

        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(config!.ConnectionString, options =>
            {
                options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);

            });
        }
        );
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IShipmentRepository, ShipmentRepository>();
        return services;
    }
}