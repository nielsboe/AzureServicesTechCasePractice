using Domain2.Interfaces;
using Infrastructure.Databases;
using Infrastructure.Databases.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Servicebus;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterServiceBus(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ServicebusOptions>(configuration.GetSection(ServicebusOptions.SectionName));
        services.AddScoped<IServiceBusSenderClient, AzureServiceBusClient>();

        return services;
    }
}