using Application.Interfaces;
using Application.Orders.Queries;
using Application.Products;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Presentation.DTOs;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IServiceBusSenderClient senderClient, 
        IQueryHandler<GetAllOrdersQuery, ICollection<Order>> getAllOrders) : Controller
    {
        IServiceBusSenderClient _senderClient =  senderClient;
        IQueryHandler<GetAllOrdersQuery, ICollection<Order>> _getAllOrders = getAllOrders;

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders(GetAllOrdersQuery query)
        {
            return Ok(await _getAllOrders.Handle(query));
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
