using DataAccessLayer.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using DomainLayer;


namespace WebAPI.Controllers
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

        [HttpGet("GetProduct")]
        public ProductDTO GetProduct(int productId)
        {
            return _mapsterMapper.Map<ProductDTO>(_inventoryRepository.GetProduct(productId));
        }

        [HttpGet("GetOrder")]
        public OrderDTO GetOrder(int orderId)
        {
            return _mapsterMapper.Map<OrderDTO>(_orderRepository.GetOrder(orderId));
        }

        [HttpGet("GetShipment")]
        public ShipmentDTO GetShipment(int shipmentId)
        {
            return _mapsterMapper.Map<ShipmentDTO>(_shipmentRepository.GetShipment(shipmentId));
        }
    }
}
