using Azure.Messaging.ServiceBus;
using DataAccessLayer.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ShippingAPI.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IShipmentRepository _shipmentRepository;

        public ShippingController(IConfiguration config, IShipmentRepository shipmentRepository)
        {
            _config = config;
            _shipmentRepository = shipmentRepository;
        }

        [HttpGet("GetShipment")]
        public Shipment GetShipment(int shipmentId)
        {
            return _shipmentRepository.GetShipment(shipmentId);
        }

        [HttpPost("CreateShipment")]
        public async Task CreateShipment(Shipment shipment)
        {
            Post(shipment, "create-order");
        }

        [HttpPost("UpdateShipment")]
        public async Task UpdateShipment(Shipment shipment)
        {
            Post(shipment, "update-order");
        }

        [HttpPost("DeleteShipment")]
        public async Task DeleteShipment(Shipment shipment)
        {
            Post(shipment, "delete-order");
        }

        [HttpPost("SendShipmentMessage")]
        public async Task Post(Shipment shipment, string task)
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
