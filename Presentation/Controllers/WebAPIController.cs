using Domain.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;


namespace Presentation.Controllers
{
    public class WebAPIController(
        IMapper mapsterMapper, 
        IInventoryRepository inventoryRepository,
        IOrderRepository orderRepository,
        IShipmentRepository shipmentRepository) : Controller
    {
        private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IShipmentRepository _shipmentRepository = shipmentRepository;
        private readonly IMapper _mapsterMapper = mapsterMapper;


    }
}
