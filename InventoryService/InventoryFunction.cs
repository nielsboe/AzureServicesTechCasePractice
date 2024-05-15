using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventoryService
{
    public class InventoryFunction
    {
        private readonly ILogger<InventoryFunction> _logger;

        public InventoryFunction(ILogger<InventoryFunction> logger)
        {
            _logger = logger;
        }

        [Function("CreateProduct")]
        public async Task CreateProductAsync([ServiceBusTrigger("myqueue", Connection = "")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }

        [Function("UpdateProduct")]
        public void UpdateProduct([ServiceBusTrigger("update-product", Connection = "ServiceBusEndpoint")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

        [Function("DeleteProduct")]
        public void DeleteProduct([ServiceBusTrigger("delete-product", Connection = "ServiceBusEndpoint")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}