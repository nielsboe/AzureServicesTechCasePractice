using Domain;

namespace Application.Interfaces;

public interface IOrderRepository
{
    Task<int> Create(Order order, CancellationToken cancellationToken);
    Task Delete(string name, CancellationToken cancellationToken);
    Task<Order> Get(int id, CancellationToken cancellationToken);
    Task<ICollection<Order>> All(CancellationToken cancellationToken);
    Task Update(Order order, CancellationToken cancellationToken);
}