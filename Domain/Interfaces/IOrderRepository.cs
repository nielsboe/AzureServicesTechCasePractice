namespace Domain.Interfaces;

public interface IOrderRepository
{
    ICollection<Order> GetOrders();
    Order GetOrder(int id);
    bool OrderExists(int id);
    bool Save();
}