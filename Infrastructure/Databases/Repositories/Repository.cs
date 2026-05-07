using Application.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Databases.Repositories;

public class Repository<T>(DataContext context) : IRepository<T> where T: class, IEntity
{
    private readonly DataContext _context = context;

    public async Task<ICollection<T>> All(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().OrderBy(i => i.Id)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<T> Get(int id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .SingleAsync(i => i.Id == id, cancellationToken);
    }

    public async Task<int> Create(T item, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(item, cancellationToken); 
        await _context.SaveChangesAsync(cancellationToken);

        return item.Id;
    }

    public async Task Update(T item, CancellationToken cancellationToken)
    {
        _context.Set<T>().Update(item);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var itemToBeRemoved = await _context.Set<T>().SingleAsync(i => i.Id == id, cancellationToken);
        _context.Set<T>().Remove(itemToBeRemoved);
        await _context.SaveChangesAsync(cancellationToken);
    }
}