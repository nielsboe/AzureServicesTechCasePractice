using Azure.Messaging.ServiceBus;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Domain;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ShipmentService
{
    public class ShipmentFunction
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly ILogger<ShipmentFunction> _logger;

        public ShipmentFunction(ILogger<ShipmentFunction> logger, IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
            _logger = logger;
        }

        //Listener function for creating the shipment
        [Function("CreateShipment")]
        public async Task CreateShipment(
            [ServiceBusTrigger("create-shipment", Connection = "ServiceBusEndpoint")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {            
            // Check if the message body is null or empty
            if (message.Body == null)
            {
                await MessageBodyIsEmptyError(message, messageActions);
            }

            string messageBody = message.Body.ToString();

            // Deserialize the message body into a ShipmentDTO object
            ShipmentDTO? shipment = JsonSerializer.Deserialize<ShipmentDTO>(messageBody);

            if (shipment == null)
            {
                await ShipmentIsEmptyError(message, messageActions);
            }

            //Create the shipment in the database
            _shipmentRepository.CreateShipment(shipment);

            // Log the shipment details
            LogDetails(shipment);

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
            // Check if the message body is null or empty
            if (message.Body == null)
            {
                await MessageBodyIsEmptyError(message, messageActions);
            }

            string messageBody = message.Body.ToString();

            // Deserialize the message body into a ShipmentDTO object
            ShipmentDTO? shipment = JsonSerializer.Deserialize<ShipmentDTO>(messageBody);

            if (shipment == null)
            {
                await ShipmentIsEmptyError(message, messageActions);
            }

            //Update the shipment in the database
            _shipmentRepository.UpdateShipment(shipment);

            // Log the shipment details
            LogDetails(shipment);

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
            // Check if the message body is null or empty
            if (message.Body == null)
            {
                await MessageBodyIsEmptyError(message, messageActions);
            }

            string messageBody = message.Body.ToString();

            // Deserialize the message body into a ShipmentDTO object
            ShipmentDTO? shipment = JsonSerializer.Deserialize<ShipmentDTO>(messageBody);

            if (shipment == null)
            {
                await ShipmentIsEmptyError(message, messageActions);
            }

            //Delete the shipment in the database
            _shipmentRepository.DeleteShipment(shipment);

            // Log the shipment details
            LogDetails(shipment);

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

        public async Task ShipmentIsEmptyError(ServiceBusReceivedMessage message, ServiceBusMessageActions messageActions)
        {
            _logger.LogError("Received an empty message body.");
            await messageActions.DeadLetterMessageAsync(message,
                new Dictionary<string, object>
                {
                            { "DeadLetterReason", "NullShipment" },
                            { "DeadLetterErrorDescription", "The shipment was null." }
                });
            return;
        }

        private void LogDetails(ShipmentDTO shipment)
        {
            _logger.LogInformation($"Received Product: {Environment.NewLine} " +
            $"Id: {shipment.Id}, {Environment.NewLine}" +
            $"OrderId: {shipment.OrderId}, {Environment.NewLine}" +
            $"Shipping address: {shipment.ShipmentAddress} {Environment.NewLine}" +
            $"Shipping date: {shipment.ShipmentDate} {Environment.NewLine}");
        }
    }
}
