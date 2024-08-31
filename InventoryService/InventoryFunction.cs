using Azure.Messaging.ServiceBus;
using Domain;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace InventoryService
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
                MessageBodyIsEmptyError(message, messageActions);
            }

            // Get the message body as a string
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            Product product = JsonSerializer.Deserialize<Product>(messageBody);

            if (product == null)
            {
                ProductIsEmptyError(message, messageActions);
            }

            // Log the product details
            _logger.LogInformation("Received Product: \n, " +
                "Id: {Id}\\", product.Id + "\n," +
                "ProductId: {ProductId}", product.ProductId + "\n," +
                "Name: {Name}", product.Name + "\n," +
                "Description: {Description}", product.Description + "\n," +
                "Price: {Price}", product.Price);

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
            Product product = JsonSerializer.Deserialize<Product>(messageBody);

            if (product == null)
            {
                await ProductIsEmptyError(message, messageActions);
            }

            // Log the product details
            _logger.LogInformation($"Received Product: {Environment.NewLine} " +
                $"Id: {product.Id}, {Environment.NewLine}" +
                $"ProductId: {product.ProductId}, {Environment.NewLine}" +
                $"Name: {product.Name} {Environment.NewLine}" +
                $"Description: {product.Description} {Environment.NewLine}" +
                $"Price: {product.Price}");

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
            Product product = JsonSerializer.Deserialize<Product>(messageBody);

            if (product == null)
            {
                await ProductIsEmptyError(message, messageActions);
            }

            // Log the product details
            _logger.LogInformation($"Received Product: {Environment.NewLine} " +
                $"Id: {product.Id}, {Environment.NewLine}" +
                $"ProductId: {product.ProductId}, {Environment.NewLine}" +
                $"Name: {product.Name} {Environment.NewLine}" +
                $"Description: {product.Description} {Environment.NewLine}" +
                $"Price: {product.Price}");

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
    }
}
