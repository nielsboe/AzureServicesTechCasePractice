using Azure.Messaging.ServiceBus;
using Presentation.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Domain.Interfaces;

namespace Application.AzureSBSenders
{
    public class InventorySender(
        IConfiguration config,
        IServiceBusClient serviceBusClient) : Controller
    {
        private readonly IConfiguration _config = config;
        IServiceBusClient _serviceBusClient = serviceBusClient;

        [HttpPost("SendProductMessage")]
        public async Task Post(ProductDTO product, string task)
        {
            var connectionString = _config.GetConnectionString("ServiceBusEndpoint");
            var client = new ServiceBusClient(connectionString);
            var sender = _serviceBusClient.CreateSender(task);
            var body = JsonSerializer.Serialize(product);
            var message = new ServiceBusMessage(body);
            await sender.SendMessageAsync(message);
        }
    }
}