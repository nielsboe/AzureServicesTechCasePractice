using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Workers.DTOs.Orders;
using Workers.DTOs.Products;
using Workers.DTOs.Shipments;
using Application.Interfaces;
using Application.Products.Commands;
using Application.Orders.Commands;
using Application.Shipments.Commands;
using Domain;

namespace Workers;

public class Functions(ILogger<Functions> logger,
    ICommandHandler<CreateProductCommand, int> _createProductHandler,
    ICommandHandler<UpdateProductCommand> _updateProductHandler,
    ICommandHandler<DeleteProductCommand> _deleteProductHandler,
    ICommandHandler<CreateOrderCommand, int> _createOrderHandler,
    ICommandHandler<UpdateOrderCommand> _updateOrderHandler,
    ICommandHandler<DeleteOrderCommand> _deleteOrderHandler, 
    ICommandHandler<CreateShipmentCommand, int> _createShipmentHandler,
    ICommandHandler<UpdateShipmentCommand> _updateShipmentHandler,
    ICommandHandler<DeleteShipmentCommand> _deleteShipmentHandler)
{
    private readonly ILogger<Functions> _logger = logger;

    #region Products

    // Listener function for creating the product
    [FunctionName("CreateProduct")]
    public async Task CreateProduct(
        [ServiceBusTrigger("create-product", Connection = "ServiceBusEndpoint")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        CancellationToken cancellationToken)
    {
        // Get the message body as a string
        string messageBody = message.Body.ToString();

        // Deserialize the message body into a Product object
        var productDto = JsonSerializer.Deserialize<CreateProductDto>(messageBody) ?? throw new Exception("Message body is empty");

        await _createProductHandler.Handle(new CreateProductCommand(CreateProductDto.Map(productDto), cancellationToken)); 

        // Complete the message
        await messageActions.CompleteMessageAsync(message, cancellationToken);
    }

    // Listener function for updating the product
    [FunctionName("UpdateProduct")]
    public async Task UpdateProduct(
        [ServiceBusTrigger("update-product", Connection = "ServiceBusEndpoint")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        CancellationToken cancellationToken)
    {
        // Get the message body as a string
        string messageBody = message.Body.ToString();

        // Deserialize the message body into a Product object
        var productDto = JsonSerializer.Deserialize<UpdateProductDto>(messageBody) ?? throw new Exception("Message body is empty");

        await _updateProductHandler.Handle(new UpdateProductCommand(UpdateProductDto.Map(productDto), cancellationToken));

        // Complete the message
        await messageActions.CompleteMessageAsync(message, cancellationToken);
    }

    // Listener function for updating the product
    [FunctionName("DeleteProduct")]
    public async Task DeleteProduct(
        [ServiceBusTrigger("update-product", Connection = "ServiceBusEndpoint")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        CancellationToken cancellationToken)
    {
        // Get the message body as a string
        string messageBody = message.Body.ToString();

        // Deserialize the message body into a Product object
        var productDto = JsonSerializer.Deserialize<DeleteProductDto>(messageBody) ?? throw new Exception("Message body is empty");

        await _deleteProductHandler.Handle(new DeleteProductCommand(DeleteProductDto.Map(productDto).InternalProductId, cancellationToken));

        // Complete the message
        await messageActions.CompleteMessageAsync(message, cancellationToken);
    }

    #endregion

    #region Orders
    // Listener function for creating the order
    [FunctionName("CreateOrder")]
    public async Task CreateOrder(
        [ServiceBusTrigger("create-order", Connection = "ServiceBusEndpoint")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        CancellationToken cancellationToken)
    {
        // Get the message body as a string
        string messageBody = message.Body.ToString();

        // Deserialize the message body into an order DTO
        var orderDto = JsonSerializer.Deserialize<CreateOrderDto>(messageBody) ?? throw new Exception("Message body is empty");

        await _createOrderHandler.Handle(new CreateOrderCommand(CreateOrderDto.Map(orderDto), cancellationToken));

        // Complete the message
        await messageActions.CompleteMessageAsync(message, cancellationToken);
    }

    // Listener function for updating the order
    [FunctionName("UpdateOrder")]
    public async Task UpdateOrder(
        [ServiceBusTrigger("update-order", Connection = "ServiceBusEndpoint")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        CancellationToken cancellationToken)
    {
        // Get the message body as a string
        string messageBody = message.Body.ToString();

        // Deserialize the message body into an order DTO
        var orderDto = JsonSerializer.Deserialize<UpdateOrderDto>(messageBody) ?? throw new Exception("Message body is empty");

        await _updateOrderHandler.Handle(new UpdateOrderCommand(UpdateOrderDto.Map(orderDto), cancellationToken));

        // Complete the message
        await messageActions.CompleteMessageAsync(message, cancellationToken);
    }

    // Listener function for deleting the order
    [FunctionName("DeleteOrder")]
    public async Task DeleteOrder(
        [ServiceBusTrigger("delete-order", Connection = "ServiceBusEndpoint")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        CancellationToken cancellationToken)
    {
        // Get the message body as a string
        string messageBody = message.Body.ToString();

        // Deserialize the message body into a delete DTO
        var orderDto = JsonSerializer.Deserialize<DeleteOrderDto>(messageBody) ?? throw new Exception("Message body is empty");

        await _deleteOrderHandler.Handle(new DeleteOrderCommand(DeleteOrderDto.Map(orderDto).InternalOrderId, cancellationToken));

        // Complete the message
        await messageActions.CompleteMessageAsync(message, cancellationToken);
    }


    #endregion

    #region Shipments
    // Listener function for creating the shipment
    [FunctionName("CreateShipment")]
    public async Task CreateShipment(
        [ServiceBusTrigger("create-shipment", Connection = "ServiceBusEndpoint")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        CancellationToken cancellationToken)
    {
        // Get the message body as a string
        string messageBody = message.Body.ToString();

        // Deserialize the message body into a delete DTO
        var dto = JsonSerializer.Deserialize<CreateShipmentDto>(messageBody) ?? throw new Exception("Message body is empty");

        await _createShipmentHandler.Handle(new CreateShipmentCommand(CreateShipmentDto.Map(dto), cancellationToken));

        // Complete the message
        await messageActions.CompleteMessageAsync(message, cancellationToken);
    }

    // Listener function for updating the shipment
    [FunctionName("UpdateShipment")]
    public async Task UpdateShipment(
        [ServiceBusTrigger("update-shipment", Connection = "ServiceBusEndpoint")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        CancellationToken cancellationToken)
    {
        // Get the message body as a string
        string messageBody = message.Body.ToString();

        // Deserialize the message body into a delete DTO
        var shipmentDto = JsonSerializer.Deserialize<UpdateShipmentDto>(messageBody) ?? throw new Exception("Message body is empty");

        await _updateShipmentHandler.Handle(new UpdateShipmentCommand(UpdateShipmentDto.Map(shipmentDto), cancellationToken));

        // Complete the message
        await messageActions.CompleteMessageAsync(message, cancellationToken);
    }

    // Listener function for deleting the shipment
    [FunctionName("DeleteShipment")]
    public async Task DeleteShipment(
        [ServiceBusTrigger("delete-shipment", Connection = "ServiceBusEndpoint")]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        CancellationToken cancellationToken)
    {
        // Get the message body as a string
        string messageBody = message.Body.ToString();

        // Deserialize the message body into a delete DTO
        var shipmentDto = JsonSerializer.Deserialize<DeleteShipmentDto>(messageBody) ?? throw new Exception("Message body is empty");
        
        await _deleteShipmentHandler.Handle(new DeleteShipmentCommand(DeleteShipmentDto.Map(shipmentDto).InternalShipmentId, cancellationToken));

        // Complete the message
        await messageActions.CompleteMessageAsync(message, cancellationToken);
    }

    #endregion
}