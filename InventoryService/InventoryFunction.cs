using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace InventoryService
{
    public class InventoryFunction
    {
        [FunctionName("CreateInventoryItem")]
        public void CreateInventoryItem([ServiceBusTrigger("create-inventory-item", Connection = "Endpoint=sb://darwintechcase.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9tVUSO5MIqQXAlsSCFvQUN6kVUJB0zlB6+ASbPwksdA=")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

        [FunctionName("UpdateInventoryItem")]
        public void UpdateInventoryItem([ServiceBusTrigger("update-inventory-item", Connection = "Endpoint=sb://darwintechcase.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9tVUSO5MIqQXAlsSCFvQUN6kVUJB0zlB6+ASbPwksdA=")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

        [FunctionName("DeleteInventoryItem")]
        public void DeleteInventoryItem([ServiceBusTrigger("delete-inventory-item", Connection = "Endpoint=sb://darwintechcase.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9tVUSO5MIqQXAlsSCFvQUN6kVUJB0zlB6+ASbPwksdA=")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}