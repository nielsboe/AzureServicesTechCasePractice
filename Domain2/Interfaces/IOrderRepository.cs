namespace Domain2.Interfaces;

public interface IOrderRepository
{
    Task<int> Create(Order order, CancellationToken cancellationToken);
    Task Delete(string name);
    Task<Order> Get(int id);
    Task<ICollection<Order>> All();
    Task Update(Order order);
}