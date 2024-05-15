using Azure.Messaging.ServiceBus;
using DataAccessLayer.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IConfiguration config, IInventoryRepository inventoryRepository)
        {
            _config = config;
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet("GetProduct")]
        public Product GetProduct(int productId)
        {
            return _inventoryRepository.GetProduct(productId);
        }

        [HttpPost("CreateProduct")]
        public async Task CreateProduct(Product product)
        {
            Post(product, "create-product");
        }

        [HttpPost("UpdateProduct")]
        public async Task UpdateProduct(Product product)
        {
            Post(product, "update-product");
        }

        [HttpPost("DeleteProduct")]
        public async Task DeleteProduct(Product product)
        {
            Post(product, "delete-product");
        }

        [HttpPost("SendProductMessage")]
        public async Task Post(Product product, string task)
        {
            var connectionString = _config.GetConnectionString("ServiceBusEndpoint");
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(task);
            var body = JsonSerializer.Serialize(product);
            var message = new ServiceBusMessage(body);
            await sender.SendMessageAsync(message);
        }
    }
}
