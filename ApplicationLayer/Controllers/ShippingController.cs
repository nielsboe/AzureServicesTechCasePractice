using Azure.Messaging.ServiceBus;
using DataAccessLayer.Interfaces;
using DomainLayer;
using InfrastructureLayer.AzureSBSenders;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ShippingAPI.Controllers
{
    public class ShippingController(
        IConfiguration config, 
        IShipmentRepository shipmentRepository, 
        IMapper mapsterMapper,
        ShipmentSender shipmentSender) : Controller
    {
        private readonly IConfiguration _config = config;
        private readonly IMapper _mapsterMapper = mapsterMapper;
        private readonly IShipmentRepository _shipmentRepository = shipmentRepository;
        private readonly ShipmentSender _shipmentSender = shipmentSender;

        [HttpPost("CreateShipment")]
        public async Task CreateShipment(ShipmentDTO shipmentDTO)
        {
            await shipmentSender.Post(shipmentDTO, "create-order");
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
    }
}
