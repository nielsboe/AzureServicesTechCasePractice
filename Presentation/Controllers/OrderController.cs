using Application2.Products;
using Domain2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IServiceBusSenderClient _senderClient;

        public OrderController(IServiceBusSenderClient senderClient)
        {
            _senderClient = senderClient;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(OrderDTO orderDTO)
        {
            await _senderClient.Send(orderDTO, "create-order");
            return Ok();
        }

        [HttpPost("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(OrderDTO orderDTO)
        {
            await _senderClient.Send(orderDTO, "update-order");
            return Ok();
        }

        [HttpPost("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(OrderDTO orderDTO)
        {
            await _senderClient.Send(orderDTO, "delete-order");
            return Ok();
        }
    }
}
