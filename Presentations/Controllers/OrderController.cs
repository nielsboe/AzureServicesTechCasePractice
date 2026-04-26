using Application.Products;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IServiceBusSenderClient senderClient, IGetAllOrders getAllOrders) : Controller
    {
        IServiceBusSenderClient _senderClient =  senderClient;
        IGetAllOrders _getAllOrders = getAllOrders;

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _getAllOrders.All());
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
