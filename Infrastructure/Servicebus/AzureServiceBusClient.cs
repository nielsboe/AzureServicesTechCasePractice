using Application.Interfaces;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Infrastructure.Servicebus;

public class AzureServiceBusClient : IServiceBusSenderClient
{
    private readonly ServiceBusClient _client;
    
    public AzureServiceBusClient(IOptions<ServicebusOptions> options)
    {
        _client = new ServiceBusClient(options.Value.ConnectionString);
    }

    public async Task Send<T>(T topic, string task)
    {
        var sender = _client.CreateSender(task);
        var body = JsonSerializer.Serialize(topic);
        var sbMessage = new ServiceBusMessage(body);

        await sender.SendMessageAsync(sbMessage);
    }
}