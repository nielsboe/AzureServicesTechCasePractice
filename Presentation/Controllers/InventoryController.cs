using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        [HttpGet("GetProduct")]
        public async Task GetProduct(ProductDTO productDTO)
        {
            await Post(productDTO, "get-product");
        }

        [HttpPut("CreateProduct")]
        public async Task CreateProduct(ProductDTO productDTO)
        {
            await Post(productDTO, "create-product");
        }

        [HttpPost("UpdateProduct")]
        public async Task UpdateProduct(ProductDTO productDTO)
        {
            await Post(productDTO, "update-product");
        }

        [HttpDelete("DeleteProduct")]
        public async Task DeleteProduct(ProductDTO productDTO)
        {
            await Post(productDTO, "delete-product");
        }
    }
}