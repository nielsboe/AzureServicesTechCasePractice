using DataAccessLayer.Interfaces;
using InfrastructureLayer.AzureSBSenders;
using Domainlayer.DTO;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController(IConfiguration config, IInventoryRepository inventoryRepository, IMapper mapsterMapper) : Controller
    {
        private readonly IConfiguration _config = config;
        private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
        private readonly IMapper _mapsterMapper = mapsterMapper;

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