using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;

namespace Presentation.Controllers
{
    public class ShippingController : Controller
    {

        [HttpGet("GetShipment")]
        public async Task GetShipment(ShipmentDTO shipmentDTO)
        {
            await Post(shipmentDTO, "get-order");
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
    }
}
