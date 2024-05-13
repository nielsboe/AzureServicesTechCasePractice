using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Models;
using System.Text.Json;

namespace AzureServiceBusQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : Controller
    {
        private readonly IConfiguration _config;

        public QueueController(IConfiguration config)
        {
            this._config = config;
        }

        [HttpPost]
        public async Task Post(Order order)
        {
            var connectionString = _config.GetConnectionString("ServiceBusEndpoint");
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender("create-order");
            var body = JsonSerializer.Serialize(order);
            var message = new ServiceBusMessage(body);
            await sender.SendMessageAsync(message);
        }
    }
}