using Application.Interfaces;
using Domain;
using Application.Orders.Commands;

namespace Application.Orders;

public class OrderHandler(IOrderRepository orderRepository) : IOrderHandler
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<int> Create(CreateOrderCommand createOrderCommand)
    {
        return await _orderRepository.Create(createOrderCommand.order, createOrderCommand.cancellationToken);
    }

    public async Task Update(UpdateOrderCommand updateOrderCommand)
    {
        await _orderRepository.Update(updateOrderCommand.order, updateOrderCommand.cancellationToken);
    }

    public async Task Delete(DeleteOrderCommand deleteOrderCommand)
    {
        await _orderRepository.Delete(deleteOrderCommand.customerName, deleteOrderCommand.cancellationToken);
    }
}
