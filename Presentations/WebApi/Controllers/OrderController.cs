using Application.Interfaces;
using Application.Orders.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IServiceBusSenderClient senderClient, 
        IQueryHandler<GetAllOrdersQuery, ICollection<Order>> getAllOrdersHandler) : Controller
    {
        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetSingleOrder(OrderDTO orderDTO)
        {
            await senderClient.Send(orderDTO, "get-order");
            return Ok();
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders(CancellationToken cancellationToken)
        {
            return Ok(await getAllOrdersHandler.Handle(new GetAllOrdersQuery(), cancellationToken));
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(OrderDTO orderDTO)
        {
            await senderClient.Send(orderDTO, "create-order");
            return Ok();
        }

        [HttpPost("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(OrderDTO orderDTO)
        {
            await senderClient.Send(orderDTO, "update-order");
            return Ok();
        }

        [HttpPost("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(OrderDTO orderDTO)
        {
            await senderClient.Send(orderDTO, "delete-order");
            return Ok();
        }
    }
}