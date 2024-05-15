using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Domain;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace OrderService
{
    public class OrderFunction
    {
        private readonly ILogger<OrderFunction> _logger;

        public OrderFunction(ILogger<OrderFunction> logger)
        {
            _logger = logger;
        }

        //Listener function for creating the order
        [Function("CreateOrder")]
        public async Task CreateOrder(
            [ServiceBusTrigger("create-order", Connection = "ServiceBusEndpoint")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            Order order = JsonSerializer.Deserialize<Order>(messageBody);

            // Log the product details
            _logger.LogInformation("Received Shipment:");
            _logger.LogInformation("Id: {Id}", order.Id);
            _logger.LogInformation("ProductId: {ProductId}", order.OrderId);
            _logger.LogInformation("Name: {Name}", order.CustomerName);
            _logger.LogInformation("Description: {Description}", order.OrderDate);
            _logger.LogInformation("Description: {Description}", order.Products);
            _logger.LogInformation("Description: {Description}", order.TotalOrderPrice);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }

        //Listener function for updating the order
        [Function("UpdateOrder")]
        public async Task UpdateOrder(
            [ServiceBusTrigger("update-order", Connection = "ServiceBusEndpoint")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            Order order = JsonSerializer.Deserialize<Order>(messageBody);

            // Log the product details
            _logger.LogInformation("Received Shipment:");
            _logger.LogInformation("Id: {Id}", order.Id);
            _logger.LogInformation("ProductId: {ProductId}", order.OrderId);
            _logger.LogInformation("Name: {Name}", order.CustomerName);
            _logger.LogInformation("Description: {Description}", order.OrderDate);
            _logger.LogInformation("Description: {Description}", order.Products);
            _logger.LogInformation("Description: {Description}", order.TotalOrderPrice);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }

        //Listener function for deleting the order
        [Function("DeleteOrder")]
        public async Task DeleteOrder(
            [ServiceBusTrigger("delete-order", Connection = "ServiceBusEndpoint")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            string messageBody = message.Body.ToString();

            // Deserialize the message body into a Product object
            Order order = JsonSerializer.Deserialize<Order>(messageBody);

            // Log the product details
            _logger.LogInformation("Received Shipment:");
            _logger.LogInformation("Id: {Id}", order.Id);
            _logger.LogInformation("ProductId: {ProductId}", order.OrderId);
            _logger.LogInformation("Name: {Name}", order.CustomerName);
            _logger.LogInformation("Description: {Description}", order.OrderDate);
            _logger.LogInformation("Description: {Description}", order.Products);
            _logger.LogInformation("Description: {Description}", order.TotalOrderPrice);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
