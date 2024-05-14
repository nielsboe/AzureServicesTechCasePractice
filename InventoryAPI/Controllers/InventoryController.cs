using Azure.Messaging.ServiceBus;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IConfiguration _config;

        public InventoryController(IConfiguration config)
        {
            this._config = config;
        }

        [HttpGet]
        public Product GetProduct(int productId)
        {
            return _inventoryRepository.GetProduct(productId);
        }

        [HttpPost]
        public async Task CreateProduct(Product product)
        {
            Post(product, "create-inventory-item");
        }

        [HttpPost]
        public async Task UpdateProduct(Product product)
        {
            Post(product, "update-inventory-item");
        }

        [HttpPost]
        public async Task DeleteProduct(Product product)
        {
            Post(product, "delete-inventory-item");
        }

        [HttpPost]
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
