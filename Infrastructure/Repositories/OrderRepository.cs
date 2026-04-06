using Domain;
using MapsterMapper;
using Application.Data;

namespace Application.Repositories;

public class OrderRepository(DataContext context, IMapper mapsterMapper) : IOrderRepository
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapsterMapper = mapsterMapper;

    public bool OrderExists(int id)
    {
        return _context.Orders.Any(o => o.Id == id);
    }

    public bool CreateOrder(Order order)
    {
        _context.Orders.Add(order);
        return Save();
    }

    public ICollection<Order> GetOrders()
    {
        return _context.Orders.OrderBy(o => o.OrderId).ToList();
    }

    public Order GetOrder(int id)
    {
        return _context.Orders.FirstOrDefault(o => o.Id == id) ?? throw new Exception("Order not found");
    }

    public bool UpdateOrder(Order order)
    {
        _context.Orders.Update(order);
        return Save();
    }

    public bool DeleteOrder(Order order)
    {
        _context.Orders.Remove(order);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}