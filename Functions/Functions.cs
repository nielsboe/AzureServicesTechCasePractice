using Application2.Products;
using Azure.Messaging.ServiceBus;
using Domain2;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Workers.DTOs.Orders;
using Application2.Orders;
using Application2.Shipments;
using Workers.DTOs.Products;
using Workers.DTOs.Shipments;

namespace Functions;

public class Functions(ILogger<Functions> logger, IProductHandler productHandler, IOrderHandler orderHandler, IShipmentHandler shipmentHandler)
{
    private readonly ILogger<Functions> _logger = logger;
    private readonly IProductHandler _productHandler = productHandler;
    private readonly IOrderHandler _orderHandler = orderHandler;
    private readonly IShipmentHandler _shipmentHandler = shipmentHandler;

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
        var productDto = JsonSerializer.Deserialize<CreateProductDto>(messageBody);

        await _productHandler.Create(CreateProductDto.Map(productDto), cancellationToken); 

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
        var productDto = JsonSerializer.Deserialize<UpdateProductDto>(messageBody);

        await _productHandler.Update(UpdateProductDto.Map(productDto));

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
        var productDto = JsonSerializer.Deserialize<DeleteProductDto>(messageBody);

        await _productHandler.Delete(productDto.Name);

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
        var orderDto = JsonSerializer.Deserialize<CreateOrderDto>(messageBody);

        await _orderHandler.Create(CreateOrderDto.Map(orderDto), cancellationToken);

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
        var orderDto = JsonSerializer.Deserialize<UpdateOrderDto>(messageBody);

        await _orderHandler.Update(UpdateOrderDto.Map(orderDto));

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
        var orderDto = JsonSerializer.Deserialize<DeleteOrderDto>(messageBody);

        await _orderHandler.Delete(orderDto.CustomerName);

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
        string messageBody = message.Body.ToString();
        var dto = JsonSerializer.Deserialize<CreateShipmentDto>(messageBody);
        await _shipmentHandler.Create(CreateShipmentDto.Map(dto), cancellationToken);
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
        string messageBody = message.Body.ToString();
        var dto = JsonSerializer.Deserialize<UpdateShipmentDto>(messageBody);
        await _shipmentHandler.Update(UpdateShipmentDto.Map(dto));
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
        string messageBody = message.Body.ToString();
        var dto = JsonSerializer.Deserialize<DeleteShipmentDto>(messageBody);
        await _shipmentHandler.Delete(dto.ShipmentId);
        await messageActions.CompleteMessageAsync(message, cancellationToken);
    }

    #endregion

}
