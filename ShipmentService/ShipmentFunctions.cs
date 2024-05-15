using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ShipmentService
{
    public static class ShipmentFunctions
    {
        [Function("CreateShipment")]
        public static void CreateShipment([ServiceBusTrigger("create-shipment", Connection = "ServiceBusEndpoint")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

        [Function("UpdateShipment")]
        public static void UpdateShipment([ServiceBusTrigger("update-shipment", Connection = "ServiceBusEndpoint")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }

        [Function("DeleteShipment")]
        public static void DeleteShipment([ServiceBusTrigger("delete-shipment", Connection = "ServiceBusEndpoint")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
