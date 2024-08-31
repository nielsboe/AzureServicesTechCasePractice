using Domain;

namespace DataAccessLayer.Interfaces;

public interface IOrderRepository
{
    ICollection<Order> GetOrders();
    Order GetOrder(int id);
    bool OrderExists(int id);
    bool CreateOrder(OrderDTO order);
    bool UpdateOrder(OrderDTO order);
    bool DeleteOrder(OrderDTO order);
    bool Save();
}