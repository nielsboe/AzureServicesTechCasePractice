using Azure.Messaging.ServiceBus;
using Domain;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ShipmentService
{
    public class ShipmentFunction
    {
        private readonly ILogger<ShipmentFunction> _logger;

        public ShipmentFunction(ILogger<ShipmentFunction> logger)
        {
            _logger = logger;
        }

        //Listener function for creating the shipment
        [Function("CreateShipment")]
        public async Task CreateShipment(
            [ServiceBusTrigger("create-shipment", Connection = "ServiceBusEndpoint")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            Shipment shipment = JsonSerializer.Deserialize<Shipment>(messageBody);

            // Log the product details
            _logger.LogInformation("Received Shipment:");
            _logger.LogInformation("Id: {Id}", shipment.Id);
            _logger.LogInformation("ProductId: {ProductId}", shipment.OrderId);
            _logger.LogInformation("Name: {Name}", shipment.ShipmentAddress);
            _logger.LogInformation("Description: {Description}", shipment.ShipmentDate);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }

        //Listener function for updating the shipment
        [Function("UpdateShipment")]
        public async Task UpdateShipment(
            [ServiceBusTrigger("create-shipment", Connection = "ServiceBusEndpoint")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            Shipment shipment = JsonSerializer.Deserialize<Shipment>(messageBody);

            // Log the product details
            _logger.LogInformation("Received Shipment:");
            _logger.LogInformation("Id: {Id}", shipment.Id);
            _logger.LogInformation("ProductId: {ProductId}", shipment.OrderId);
            _logger.LogInformation("Name: {Name}", shipment.ShipmentAddress);
            _logger.LogInformation("Description: {Description}", shipment.ShipmentDate);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }

        //Listener function for deleting the shipment
        [Function("DeleteShipment")]
        public async Task DeleteShipment(
            [ServiceBusTrigger("create-shipment", Connection = "ServiceBusEndpoint")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            Shipment shipment = JsonSerializer.Deserialize<Shipment>(messageBody);

            // Log the product details
            _logger.LogInformation("Received Shipment:");
            _logger.LogInformation("Id: {Id}", shipment.Id);
            _logger.LogInformation("ProductId: {ProductId}", shipment.OrderId);
            _logger.LogInformation("Name: {Name}", shipment.ShipmentAddress);
            _logger.LogInformation("Description: {Description}", shipment.ShipmentDate);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
