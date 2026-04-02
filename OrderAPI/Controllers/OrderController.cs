using Azure.Messaging.ServiceBus;
using DataAccessLayer.Interfaces;
using Domain;
using Mapster;
using MapsterMapper;
using MassTransit.Transports;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IConfiguration config, IOrderRepository orderRepository, IMapper mapsterMapper) : Controller
    {
        private readonly IConfiguration _config = config;
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IMapper _mapsterMapper = mapsterMapper;

        [HttpGet("GetOrder")]
        public OrderDTO GetOrder(int orderId)
        {
            return _mapsterMapper.Map<OrderDTO>(_orderRepository.GetOrder(orderId));
        }

        [HttpPost("CreateOrder")]
        public async Task CreateOrder(OrderDTO orderDTO)
        {
            await Post(orderDTO, "create-order");
        }

        [HttpPost("UpdateOrder")]
        public async Task UpdateOrder(OrderDTO orderDTO)
        {
            await Post(orderDTO, "update-order");
        }

        [HttpPost("DeleteOrder")]
        public async Task DeleteOrder(OrderDTO orderDTO)
        {
            await Post(orderDTO, "delete-order");
        }

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
