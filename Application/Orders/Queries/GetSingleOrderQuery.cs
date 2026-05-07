using Application.Interfaces;
using Domain;

namespace Application.Orders.Queries;
public record GetSingleOrderQuery(int orderId, CancellationToken cancellationToken);

public class GetSingleOrderHandler(IRepository<Order> orderRepository) : IQueryHandler<GetSingleOrderQuery, Order>
{
    private readonly IRepository<Order> _orderRepository = orderRepository;

    public Task<Order> Handle(GetSingleOrderQuery orderQuery)
    {
        return _orderRepository.Get(orderQuery.orderId, orderQuery.cancellationToken);
    }
}
