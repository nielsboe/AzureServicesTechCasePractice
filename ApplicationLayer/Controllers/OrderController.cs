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
    }
}
