using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace OrderService
{
    public class OrderFunction
    {
        [Function("CreateOrder")]
        public void CreateOrder([ServiceBusTrigger("create-order", Connection = "ServiceBusEndpoint")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

        [Function("UpdateOrder")]
        public void UpdateOrder([ServiceBusTrigger("update-order", Connection = "ServiceBusEndpoint")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

        [Function("DeleteOrder")]
        public void DeleteOrder([ServiceBusTrigger("delete-order", Connection = "ServiceBusEndpoint")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}