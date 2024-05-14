using Azure.Messaging.ServiceBus;
using MassTransit.Transports;
using Microsoft.AspNetCore.Mvc;
using ShippingAPI.Models;
using System.Text.Json;

namespace ShippingAPI.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IConfiguration _config;

        public ShippingController(IConfiguration config)
        {
            this._config = config;
        }

        [HttpGet]
        public Shipment GetOrder(int shipmentId)
        {
            return _shipmentRepository.GetOrder(shipmentId);
        }

        [HttpPost]
        public async Task CreateShipment(Shipment shipment)
        {
            Post(shipment, "create-order");
        }

        [HttpPost]
        public async Task UpdateShipment(Shipment shipment)
        {
            Post(shipment, "update-order");
        }

        [HttpPost]
        public async Task DeleteShipment(Shipment shipment)
        {
            Post(shipment, "delete-order");
        }

        [HttpPost]
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
