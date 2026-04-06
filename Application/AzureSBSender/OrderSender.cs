using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;
using System.Text.Json;

namespace Application.AzureSBSenders
{
    public class OrderSender(IConfiguration config) : Controller
    {
        private readonly IConfiguration _config = config;
        [HttpPost("SendOrderMessage")]
        public async Task Post(OrderDTO order, string task)
        {
            var connectionString = _config.GetConnectionString("ServiceBusEndpoint");
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(task);
            var body = JsonSerializer.Serialize(order);
            var message = new ServiceBusMessage(body);
            await sender.SendMessageAsync(message);
        }
    }
}
