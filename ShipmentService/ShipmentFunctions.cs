using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ShipmentService
{
    public static class ShipmentFunctions
    {
        [FunctionName("CreateShipment")]
        public static void CreateShipment([ServiceBusTrigger("create-shipment", Connection = "Endpoint=sb://darwintechcase.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9tVUSO5MIqQXAlsSCFvQUN6kVUJB0zlB6+ASbPwksdA=")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

        [FunctionName("UpdateShipment")]
        public static void UpdateShipment([ServiceBusTrigger("update-shipment", Connection = "Endpoint=sb://darwintechcase.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9tVUSO5MIqQXAlsSCFvQUN6kVUJB0zlB6+ASbPwksdA=")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

        [FunctionName("DeleteShipment")]
        public static void DeleteShipment([ServiceBusTrigger("delete-shipment", Connection = "Endpoint=sb://darwintechcase.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9tVUSO5MIqQXAlsSCFvQUN6kVUJB0zlB6+ASbPwksdA=")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
