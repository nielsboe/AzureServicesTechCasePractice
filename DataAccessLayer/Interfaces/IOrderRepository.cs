using Domain;

namespace DataAccessLayer.Interfaces;

public interface IOrderRepository
{
    ICollection<Order> GetOrders();
    Order GetOrder(int id);
    bool OrderExists(int id);
    bool CreateOrder(Order order);
    bool UpdateOrder(Order order);
    bool DeleteOrder(Order order);
    bool Save();
}