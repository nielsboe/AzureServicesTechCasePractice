using Application.Interfaces;
using Domain;

namespace Application.Orders.Queries;
public record GetSingleOrderQuery(int orderId, CancellationToken cancellationToken);

public class GetSingleOrderHandler(IRepository<Order> orderRepository) : IQueryHandler<GetSingleOrderQuery, Order>
{

    public Task<Order> Handle(GetSingleOrderQuery orderQuery, CancellationToken cancellationToken)
    {
        return orderRepository.Get(orderQuery.orderId, cancellationToken);
    }
}
