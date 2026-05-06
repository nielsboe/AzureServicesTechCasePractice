using Application.Interfaces;
using Domain;

namespace Application.Orders.Queries;

public record GetAllOrdersQuery;
public class GetAllOrdersHandler(IOrderRepository orderRepository) : IQueryHandler<GetAllOrdersQuery, ICollection<Order>>
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    public async Task<ICollection<Order>> Handle(GetAllOrdersQuery query)
    {
        var orders = await _orderRepository.All();

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