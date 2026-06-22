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
        [HttpGet("GetShipment")]
        public async Task<IActionResult> GetSingleShipment(ShipmentDTO shipmentDTO)
        {
            await senderClient.Send(shipmentDTO, "get-shipment");
            return Ok();
        }

        [HttpGet("GetAllhipments")]
        public async Task<IActionResult> GetAllShipments(CancellationToken cancellationToken)
        {
            return Ok(await getAllShipmentsHandler.Handle(new GetAllShipmentsQuery(), cancellationToken));
        }

        [HttpPost("CreateShipment")]
        public async Task<IActionResult> CreateShipment(ShipmentDTO shipmentDTO)
        {
            await senderClient.Send(shipmentDTO, "create-shipment");
            return Ok();
        }

        [HttpPost("UpdateShipment")]
        public async Task<IActionResult> UpdateShipment(ShipmentDTO shipmentDTO)
        {
            await senderClient.Send(shipmentDTO, "update-shipment");
            return Ok();
        }

        [HttpPost("DeleteShipment")]
        public async Task<IActionResult> DeleteShipment(ShipmentDTO shipmentDTO)
        {
            await senderClient.Send(shipmentDTO, "delete-shipment");
            return Ok();
        }
    }
}
