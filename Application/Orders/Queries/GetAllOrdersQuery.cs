using Application.Interfaces;
using Domain;

namespace Application.Orders.Queries;

public record GetAllOrdersQuery;
public class GetAllOrdersHandler(IRepository<Order> orderRepository) : IQueryHandler<GetAllOrdersQuery, ICollection<Order>>
{
    public async Task<ICollection<Order>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
    {
        var orders = await orderRepository.All(cancellationToken);

        return orders.Select(o => new Order
        {
            CustomerName = o.CustomerName,
            OrderDate = o.OrderDate,
            IsShipped = o.IsShipped,
            Products = o.Products,
            TotalOrderPrice = o.TotalOrderPrice
        }).ToList();
    }
}