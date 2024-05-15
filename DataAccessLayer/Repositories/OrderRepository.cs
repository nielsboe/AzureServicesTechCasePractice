using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using Domain;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
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
            return _context.Orders.Where(o => o.Id == id).FirstOrDefault();
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
            return saved > 0 ? true : false;
        }
    }
}
