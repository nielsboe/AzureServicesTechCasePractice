using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : Controller
    {
        private readonly IServiceBusSenderClient _senderClient;

        public ShippingController(IServiceBusSenderClient senderClient)
        {
            _senderClient = senderClient;
        }

        [HttpGet("GetShipment")]
        public async Task<IActionResult> GetShipment(ShipmentDTO shipmentDTO)
        {
            await _senderClient.Send(shipmentDTO, "get-shipment");
            return Ok();
        }

        [HttpPost("CreateShipment")]
        public async Task<IActionResult> CreateShipment(ShipmentDTO shipmentDTO)
        {
            await _senderClient.Send(shipmentDTO, "create-shipment");
            return Ok();
        }

        [HttpPost("UpdateShipment")]
        public async Task<IActionResult> UpdateShipment(ShipmentDTO shipmentDTO)
        {
            await _senderClient.Send(shipmentDTO, "update-shipment");
            return Ok();
        }

        [HttpPost("DeleteShipment")]
        public async Task<IActionResult> DeleteShipment(ShipmentDTO shipmentDTO)
        {
            await _senderClient.Send(shipmentDTO, "delete-shipment");
            return Ok();
        }
    }
}
