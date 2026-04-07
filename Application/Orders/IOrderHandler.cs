using Domain;

namespace Application.Orders;

public interface IOrderHandler
{
    Task<int> Create(Order order, CancellationToken cancellationToken);
    Task Delete(string name);
    Task Update(Order order);
}