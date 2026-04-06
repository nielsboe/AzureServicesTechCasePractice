using Domain2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IServiceBusSenderClient _senderClient;

        public InventoryController(IServiceBusSenderClient senderClient)
        {
            _senderClient = senderClient;
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(ProductDTO productDTO)
        {
            await _senderClient.Send(productDTO, "get-product");
            return Ok();
        }

        [HttpPut("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            await _senderClient.Send(productDTO, "create-product");
            return Ok();
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductDTO productDTO)
        {
            await _senderClient.Send(productDTO, "update-product");
            return Ok();
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(ProductDTO productDTO)
        {
            await _senderClient.Send(productDTO, "delete-product");
            return Ok();
        }
    }
}