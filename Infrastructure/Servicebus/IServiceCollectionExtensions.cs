using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Servicebus;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterServiceBus(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ServicebusOptions>(opts => configuration.GetSection(ServicebusOptions.SectionName).Bind(opts));
        services.AddScoped<IServiceBusSenderClient, AzureServiceBusClient>();

        return services;
    }
}