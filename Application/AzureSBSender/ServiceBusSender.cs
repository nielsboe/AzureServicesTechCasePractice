using Azure.Messaging.ServiceBus;
using Domain.Interfaces;
using System.Text.Json;

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