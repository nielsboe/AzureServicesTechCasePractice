using Application.Interfaces;
using Domain;

namespace Application.Orders.Queries;
public record GetSingleOrderQuery(int orderId);

public class GetSingleOrderHandler(IOrderRepository orderRepository) : IQueryHandler<GetSingleOrderQuery, Order>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public Task<Order> Handle(GetSingleOrderQuery orderQuery)
    {
        return _orderRepository.Get(orderQuery.orderId);
    }
}
