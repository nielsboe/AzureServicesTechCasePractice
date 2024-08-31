using Azure.Messaging.ServiceBus;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Domain;
using MapsterMapper;
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
        private readonly IMapper _mapsterMapper;

        public InventoryController(IConfiguration config, IInventoryRepository inventoryRepository, IMapper mapsterMapper)
        {
            _config = config;
            _inventoryRepository = inventoryRepository;
            _mapsterMapper = mapsterMapper;
        }

        [HttpGet("GetProduct")]
        public ProductDTO GetProduct(int productId)
        {
            return _mapsterMapper.Map<ProductDTO>(_inventoryRepository.GetProduct(productId));
        }

        [HttpPost("CreateProduct")]
        public async Task CreateProduct(ProductDTO productDTO)
        {
            await Post(productDTO, "create-product");
        }

        [HttpPost("UpdateProduct")]
        public async Task UpdateProduct(ProductDTO productDTO)
        {
            await Post(productDTO, "update-product");
        }

        [HttpPost("DeleteProduct")]
        public async Task DeleteProduct(ProductDTO productDTO)
        {
            await Post(productDTO, "delete-product");
        }

        [HttpPost("SendProductMessage")]
        public async Task Post(ProductDTO product, string task)
        {
            //var connectionString = _config.GetConnectionString("Endpoint=sb://darwintechcase.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9tVUSO5MIqQXAlsSCFvQUN6kVUJB0zlB6+ASbPwksdA=");
            var connectionString = _config.GetConnectionString("ServiceBusEndpoint");
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(task);
            var body = JsonSerializer.Serialize(product);
            var message = new ServiceBusMessage(body);
            await sender.SendMessageAsync(message);
        }
    }
}