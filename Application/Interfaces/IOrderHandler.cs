using Application.Orders.Commands;

namespace Application.Interfaces;

public interface IOrderHandler
{
    Task<int> Create(CreateOrderCommand createOrderCommand);
    Task Update(UpdateOrderCommand updateOrderCommand);
    Task Delete(DeleteOrderCommand deleteOrderCommand);
}