using Domain.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        [HttpGet("GetOrder")]
        public async Task GetOrder(OrderDTO orderDTO)
        {
            await Post(orderDTO, "get-order");
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
    }
}
