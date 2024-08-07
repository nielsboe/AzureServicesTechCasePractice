using Azure.Messaging.ServiceBus;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Domain;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace InventoryService2
{
    public class InventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(ILogger<InventoryService> logger, IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
            _logger = logger;
        }

        //Listener function for creating the product
        [Function("CreateProduct")]
        public async Task CreateProduct(
            [ServiceBusTrigger("create-product", Connection = "ServiceBusEndpoint")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            // Check if the message body is null or empty
            if (message.Body == null)
            {
                await MessageBodyIsEmptyError(message, messageActions);
            }

            // Get the message body as a string
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            ProductDTO? product = JsonSerializer.Deserialize<ProductDTO>(messageBody);

            if (product == null)
            {
                await ProductIsEmptyError(message, messageActions);
            }

            // Log the product details
            LogDetails(product);

            //Create the product in the database
            _inventoryRepository.CreateProduct(product);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }

        //Listener function for updating the product
        [Function("UpdateProduct")]
        public async Task UpdateProduct(
            [ServiceBusTrigger("update-product", Connection = "ServiceBusEndpoint")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            // Check if the message body is null or empty
            if (message.Body == null)
            {
                await MessageBodyIsEmptyError(message, messageActions);
            }

            // Get the message body as a string
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            ProductDTO? product = JsonSerializer.Deserialize<ProductDTO>(messageBody);

            if (product == null)
            {
                await ProductIsEmptyError(message, messageActions);
            }

            // Log the product details
            LogDetails(product);

            //Update the product in the database
            _inventoryRepository.UpdateProduct(product);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }

        //Listener function for deleting the product
        [Function("DeleteProduct")]
        public async Task DeleteProduct(
            [ServiceBusTrigger("delete-product", Connection = "ServiceBusEndpoint")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            // Check if the message body is null or empty
            if (message.Body == null)
            {
                await MessageBodyIsEmptyError(message, messageActions);
            }

            // Get the message body as a string
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            ProductDTO product = JsonSerializer.Deserialize<ProductDTO>(messageBody);

            if (product == null)
            {
                await ProductIsEmptyError(message, messageActions);
            }

            // Log the product details
            LogDetails(product);

            //Update the product in the database
            _inventoryRepository.DeleteProduct(product);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }

        public async Task MessageBodyIsEmptyError(ServiceBusReceivedMessage message, ServiceBusMessageActions messageActions)
        {
            _logger.LogError("Received an empty message body.");
            await messageActions.DeadLetterMessageAsync(message,
                new Dictionary<string, object>
                {
                            { "DeadLetterReason", "EmptyMessageBody" },
                            { "DeadLetterErrorDescription", "The message body was empty." }
                });
            return;
        }

        public async Task ProductIsEmptyError(ServiceBusReceivedMessage message, ServiceBusMessageActions messageActions)
        {
            _logger.LogError("Received an empty message body.");
            await messageActions.DeadLetterMessageAsync(message,
                new Dictionary<string, object>
                {
                            { "DeadLetterReason", "NullProduct" },
                            { "DeadLetterErrorDescription", "The product was null." }
                });
            return;
        }

        public void LogDetails(ProductDTO product)
        {
            _logger.LogInformation($"Received Product: {Environment.NewLine} " +
            $"Id: {product.Id}, {Environment.NewLine}" +
            $"ProductId: {product.ProductId}, {Environment.NewLine}" +
            $"Name: {product.Name} {Environment.NewLine}" +
            $"Description: {product.Description} {Environment.NewLine}" +
            $"Price: {product.Price}");
        }
    }
}
