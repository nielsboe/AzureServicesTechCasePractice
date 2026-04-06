using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Domain2.Interfaces;

namespace Infrastructure.Servicebus;

public class AzureServiceBusClient(ServiceBusClient client) : IServiceBusSenderClient
{
    private readonly ServiceBusClient _client = client;

    public async Task Send<T>(T topic, string task)
    {
        var sender = _client.CreateSender(task);
        var body = JsonSerializer.Serialize(topic);
        var sbMessage = new ServiceBusMessage(body);

        await sender.SendMessageAsync(sbMessage);
    }
}