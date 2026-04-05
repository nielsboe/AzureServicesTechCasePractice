using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace InfrastructureLayer.AzureSBSenders
{
    public class InventorySender(IConfiguration config) : Controller
    {
        private readonly IConfiguration _config = config;
    
        [HttpPost("SendProductMessage")]
        public async Task Post(ProductDTO product, string task)
        {
            var connectionString = _config.GetConnectionString("ServiceBusEndpoint");
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(task);
            var body = JsonSerializer.Serialize(product);
            var message = new ServiceBusMessage(body);
            await sender.SendMessageAsync(message);
        }
    }
}