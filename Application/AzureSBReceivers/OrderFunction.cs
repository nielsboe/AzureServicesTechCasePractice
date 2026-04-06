using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Domain;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Application.AzureSBReceivers;

public class OrderFunction(ILogger<OrderFunction> logger, IOrderRepository orderRepository)
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly ILogger<OrderFunction> _logger = logger;

    //Listener function for creating the order
    [Function("CreateOrder")]
    public async Task CreateOrder(
        [ServiceBusTrigger("create-order", Connection = "ServiceBusEndpoint")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        // Check if the message body is null or empty
        if (message.Body == null)
        {
            await MessageBodyIsEmptyError(message, messageActions);
            return;
        }

        string messageBody = message.Body.ToString();

        // Deserialize the message body into a OrderDTO object
        OrderDTO? order = JsonSerializer.Deserialize<OrderDTO>(messageBody);

        if (order == null)
        {
            await OrderIsEmptyError(message, messageActions);
            return;
        }

        // Log the order details
        LogDetails(order);

        //Create the order in the database
        _orderRepository.CreateOrder(order);

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
        // Check if the message body is null or empty
        if (message.Body == null)
        {
            await MessageBodyIsEmptyError(message, messageActions);
            return;
        }

        string messageBody = message.Body.ToString();

        // Deserialize the message body into a OrderDTO object
        OrderDTO? order = JsonSerializer.Deserialize<OrderDTO>(messageBody);

        if (order == null)
        {
            await OrderIsEmptyError(message, messageActions);
            return;
        }

        // Log the order details
        LogDetails(order);

        //Update the order in the database
        _orderRepository.UpdateOrder(order);

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
        // Check if the message body is null or empty
        if (message.Body == null)
        {
            await MessageBodyIsEmptyError(message, messageActions);
            return;
        }

        string messageBody = message.Body.ToString();

        // Deserialize the message body into a OrderDTO object
        OrderDTO? order = JsonSerializer.Deserialize<OrderDTO>(messageBody);

        if (order == null)
        {
            await OrderIsEmptyError(message, messageActions);
            return;
        }

        // Log the order details
        LogDetails(order);

        //Remove the order in the database
        _orderRepository.DeleteOrder(order);

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

    public async Task OrderIsEmptyError(ServiceBusReceivedMessage message, ServiceBusMessageActions messageActions)
    {
        _logger.LogError("Received an empty message body.");
        await messageActions.DeadLetterMessageAsync(message,
            new Dictionary<string, object>
            {
                            { "DeadLetterReason", "NullOrder" },
                            { "DeadLetterErrorDescription", "The order was null." }
            });
        return;
    }

    public void LogDetails(OrderDTO order)
    {
        _logger.LogInformation(
            "Received Order:\n" +
            "Id: {Id}\n" +
            "OrderId: {ProductId}\n" +
            "CustomerName: {Name}\n" +
            "OrderDate: {OrderDate}\n" +
            "Shipped: {IsShipped}\n" +
            "Amount of products: {Products.Count}\n" +
            "Price: {TotalOrderPrice}\n",
            order.Id,
            order.OrderId,
            order.CustomerName,
            order.OrderDate,
            order.IsShipped,
            order.Products.Count,
            order.TotalOrderPrice);
    }
}