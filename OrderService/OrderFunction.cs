using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace OrderService
{
    public class OrderFunction
    {
        [FunctionName("CreateOrder")]
        public void CreateOrder([ServiceBusTrigger("create-order", Connection = "Endpoint=sb://darwintechcase.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9tVUSO5MIqQXAlsSCFvQUN6kVUJB0zlB6+ASbPwksdA=")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

        [FunctionName("UpdateOrder")]
        public void UpdateOrder([ServiceBusTrigger("update-order", Connection = "Endpoint=sb://darwintechcase.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9tVUSO5MIqQXAlsSCFvQUN6kVUJB0zlB6+ASbPwksdA=")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

        [FunctionName("DeleteOrder")]
        public void DeleteOrder([ServiceBusTrigger("delete-order", Connection = "Endpoint=sb://darwintechcase.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9tVUSO5MIqQXAlsSCFvQUN6kVUJB0zlB6+ASbPwksdA=")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
