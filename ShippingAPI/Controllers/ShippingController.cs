using Azure.Messaging.ServiceBus;
using DataAccessLayer.Interfaces;
using Domain;
using MapsterMapper;
using MassTransit.Transports;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ShippingAPI.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapsterMapper;
        private readonly IShipmentRepository _shipmentRepository;

        public ShippingController(IConfiguration config, IShipmentRepository shipmentRepository, IMapper mapsterMapper)
        {
            _config = config;
            _mapsterMapper = mapsterMapper;
            _shipmentRepository = shipmentRepository;
        }

        [HttpGet("GetShipment")]
        public ShipmentDTO GetShipment(int shipmentId)
        {
            return _mapsterMapper.Map<ShipmentDTO>(_shipmentRepository.GetShipment(shipmentId));
        }

        [HttpPost("CreateShipment")]
        public async Task CreateShipment(ShipmentDTO shipmentDTO)
        {
            await Post(shipmentDTO, "create-order");
        }

        [HttpPost("UpdateShipment")]
        public async Task UpdateShipment(ShipmentDTO shipmentDTO)
        {
            await Post(shipmentDTO, "update-order");
        }

        [HttpPost("DeleteShipment")]
        public async Task DeleteShipment(ShipmentDTO shipmentDTO)
        {
            await Post(shipmentDTO, "delete-order");
        }

        [HttpPost("SendShipmentMessage")]
        public async Task Post(ShipmentDTO shipment, string task)
        {
            var connectionString = _config.GetConnectionString("ServiceBusEndpoint");
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(task);
            var body = JsonSerializer.Serialize(shipment);
            var message = new ServiceBusMessage(body);
            await sender.SendMessageAsync(message);
        }
    }
}
