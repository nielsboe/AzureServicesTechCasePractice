using Domain2;
using Domain2.Interfaces;

namespace Application2.Orders;

public class OrderHandler(IOrderRepository orderRepository) : IOrderHandler
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<int> Create(Order order, CancellationToken cancellationToken)
    {
        // Validate
        if (order.OrderDate <= DateTime.UtcNow)
        {
            throw new ArgumentException("Order should be placed before now.");
        }

        return await _orderRepository.Create(order, cancellationToken);
    }

    public async Task Update(Order order)
    {
        // Validate
        if (order.OrderDate <= DateTime.UtcNow)
        {
            throw new ArgumentException("Order should be placed before now.");
        }

        _orderRepository.Update(order);
    }

    public async Task Delete(string name)
    {
        await _orderRepository.Delete(name);
    }
}
