using Azure.Messaging.ServiceBus;
using DataAccessLayer.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IConfiguration config, IOrderRepository orderRepository)
        {
            _config = config;
            _orderRepository = orderRepository;
        }

        [HttpGet("GetOrder")]
        public Order GetOrder(int orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }

        [HttpPost("CreateOrder")]
        public async Task CreateOrder(Order order)
        {
            Post(order, "create-order");
        }

        [HttpPost("UpdateOrder")]
        public async Task UpdateOrder(Order order)
        {
            Post(order, "update-order");
        }

        [HttpPost("DeleteOrder")]
        public async Task DeleteOrder(Order order)
        {
            Post(order, "delete-order");
        }

        [HttpPost("SendOrderMessage")]
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
