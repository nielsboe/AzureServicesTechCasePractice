using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Functions;

public class Functions(ILogger<Functions> logger)
{
    private readonly ILogger<Functions> _logger = logger;

    // Listener function for creating the product
    [FunctionName("CreateProduct")]
    public async Task CreateProduct(
        [ServiceBusTrigger("create-product", Connection = "ServiceBusEndpoint")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        // Check if the message body is null or empty
        if (message.Body == null)
        {
            await  MessageBodyIsEmptyError(message, messageActions);
            return;
        }

        // Get the message body as a string
        string messageBody = message.Body.ToString();

        // Deserialize the message body into a Product object
        ProductDTO? product = JsonSerializer.Deserialize<ProductDTO>(messageBody);

        if (product == null)
        {
            await ProductIsEmptyError(message, messageActions);
            return;
        }

        // Log the product details
        LogDetails(product);

        //Create the product in the database
        _inventoryRepository.CreateProduct(product);

        // Complete the message
        await messageActions.CompleteMessageAsync(message);
    }

}