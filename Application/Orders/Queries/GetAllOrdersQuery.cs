using Application.Interfaces;
using Domain;

namespace Application.Orders.Queries;

public record GetAllOrdersQuery(CancellationToken cancellationToken);
public class GetAllOrdersHandler(IRepository<Order> orderRepository) : IQueryHandler<GetAllOrdersQuery, ICollection<Order>>
{
    private readonly IRepository<Order> _orderRepository = orderRepository;
    public async Task<ICollection<Order>> Handle(GetAllOrdersQuery query)
    {
        var orders = await _orderRepository.All(query.cancellationToken);

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