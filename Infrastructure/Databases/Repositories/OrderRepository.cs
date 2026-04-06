
using Domain2;
using Domain2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Databases.Repositories;

public class OrderRepository(DataContext context) : IOrderRepository
{
    private readonly DataContext _context = context;

    public async Task<ICollection<Order>> All()
    {
        return await _context.Orders.OrderBy(p => p.Id)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Order> Get(int id)
    {
        return await _context.Orders
            .AsNoTracking()
            .SingleAsync(p => p.Id == id);
    }

    public async Task<int> Create(Order order, CancellationToken cancellationToken)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
        _context.SaveChanges();

        return order.Id;
    }

    public async Task Update(Order order)
    {
        _context.Orders.Update(order);
        _context.SaveChanges();
    }

    public async Task Delete(string customerName)
    {
        var order = _context.Orders.Single(p => p.CustomerName == customerName);
        _context.Orders.Remove(order);
        _context.SaveChanges();
    }
}