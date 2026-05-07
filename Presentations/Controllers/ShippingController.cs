using Application.Interfaces;
using Application.Shipments.Queries;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController(IServiceBusSenderClient senderClient, 
        IQueryHandler<GetAllShipmentsQuery, IEnumerable<ShipmentDTO>> getAllShipmentsHandler) : Controller
    {
        IServiceBusSenderClient _senderClient = senderClient;
        IQueryHandler<GetAllShipmentsQuery, IEnumerable<ShipmentDTO>> _getAllShipmentsHandler = getAllShipmentsHandler;

        [HttpGet("GetShipment")]
        public async Task<IActionResult> GetSingleShipment(ShipmentDTO shipmentDTO)
        {
            await _senderClient.Send(shipmentDTO, "get-shipment");
            return Ok();
        }

        [HttpGet("GetAllhipments")]
        public async Task<IActionResult> GetAllShipments(GetAllShipmentsQuery query)
        {
            return Ok(await _getAllShipmentsHandler.Handle(query));
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
