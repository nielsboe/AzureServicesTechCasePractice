using Azure.Messaging.ServiceBus;
using Domain;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace InventoryService2
{
    public class InventoryService
    {
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(ILogger<InventoryService> logger)
        {
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
                _logger.LogError("Received an empty message body.");
                await messageActions.DeadLetterMessageAsync(message,
                    new Dictionary<string, object>
                    {
                            { "DeadLetterReason", "EmptyMessageBody" },
                            { "DeadLetterErrorDescription", "The message body was empty." }
                    });
                return;
            }

            // Get the message body as a string
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            Product product = JsonSerializer.Deserialize<Product>(messageBody);

            if (product == null)
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

            // Log the product details
            _logger.LogInformation("Received Product:");
            _logger.LogInformation("Id: {Id}", product.Id);
            _logger.LogInformation("ProductId: {ProductId}", product.ProductId);
            _logger.LogInformation("Name: {Name}", product.Name);
            _logger.LogInformation("Description: {Description}", product.Description);
            _logger.LogInformation("Price: {Price}", product.Price);

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
                _logger.LogError("Received an empty message body.");
                await messageActions.DeadLetterMessageAsync(message,
                    new Dictionary<string, object>
                    {
                            { "DeadLetterReason", "EmptyMessageBody" },
                            { "DeadLetterErrorDescription", "The message body was empty." }
                    });
                return;
            }

            // Get the message body as a string
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            Product product = JsonSerializer.Deserialize<Product>(messageBody);

            if (product == null)
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

            // Log the product details
            _logger.LogInformation("Received Product:");
            _logger.LogInformation("Id: {Id}", product.Id);
            _logger.LogInformation("ProductId: {ProductId}", product.ProductId);
            _logger.LogInformation("Name: {Name}", product.Name);
            _logger.LogInformation("Description: {Description}", product.Description);
            _logger.LogInformation("Price: {Price}", product.Price);

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
                _logger.LogError("Received an empty message body.");
                await messageActions.DeadLetterMessageAsync(message,
                    new Dictionary<string, object>
                    {
                            { "DeadLetterReason", "EmptyMessageBody" },
                            { "DeadLetterErrorDescription", "The message body was empty." }
                    });
                return;
            }

            // Get the message body as a string
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            Product product = JsonSerializer.Deserialize<Product>(messageBody);

            if (product == null)
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

            // Log the product details
            _logger.LogInformation("Received Product:");
            _logger.LogInformation("Id: {Id}", product.Id);
            _logger.LogInformation("ProductId: {ProductId}", product.ProductId);
            _logger.LogInformation("Name: {Name}", product.Name);
            _logger.LogInformation("Description: {Description}", product.Description);
            _logger.LogInformation("Price: {Price}", product.Price);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
