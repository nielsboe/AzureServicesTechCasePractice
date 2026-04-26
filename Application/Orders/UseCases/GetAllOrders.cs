using Application.Interfaces;
using Domain;

namespace Application.Orders.UseCases
{
    public class GetAllOrdersById
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersById(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ICollection<Order>> GetAllOrders(CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.All(cancellationToken);

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
}