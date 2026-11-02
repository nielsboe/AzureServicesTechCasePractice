using Application.Interfaces;
using Application.Shipments.Queries;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController(IServiceBusSenderClient senderClient, 
        IQueryHandler<GetAllShipmentsQuery, IEnumerable<ShipmentDTO>> getAllShipmentsHandler,
        IQueryHandler<GetSingleShipmentQuery, ShipmentDTO> getSingleShipmentHandler) : Controller
    {
        [HttpGet("GetShipment")]
        public async Task<IActionResult> GetSingleShipment(int shipmentId)
        {
            return Ok(await getSingleShipmentHandler.Handle(new GetSingleShipmentQuery(shipmentId), CancellationToken.None));
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
