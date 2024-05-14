using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Models;
using System.Text.Json;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IConfiguration _config;

        public OrderController(IConfiguration config)
        {
            this._config = config;
        }

        [HttpGet]
        public Order GetOrder(int orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }

        [HttpPost]
        public async Task CreateOrder(Order order)
        {
            Post(order, "create-order");
        }

        [HttpPost]
        public async Task UpdateOrder(Order order)
        {
            Post(order, "update-order");
        }

        [HttpPost]
        public async Task DeleteOrder(Order order)
        {
            Post(order, "delete-order");
        }

        [HttpPost]
        public async Task Post(Order order, string task)
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
