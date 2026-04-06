using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Domain.Interfaces;

namespace Infrastructure.Servicebus;

public class AzureServiceBusClient(ServiceBusClient client) : IServiceBusSenderClient
{
    private readonly ServiceBusClient _client = client;

    public async Task Post<T>(T topic, string task)
    {
        var sender = _client.CreateSender(task);
        var body = JsonSerializer.Serialize(topic);
        var sbMessage = new ServiceBusMessage(body);

        await sender.SendMessageAsync(sbMessage);
    }
}