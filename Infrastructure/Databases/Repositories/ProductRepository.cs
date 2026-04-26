using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Databases.Repositories;

public class ProductRepository(DataContext context) : IProductRepository
{
    private readonly DataContext _context = context;

    public async Task<ICollection<Product>> All()
    {
        return await _context.Products.OrderBy(p => p.Id)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Product> Get(int id)
    {
        return await _context.Products
            .AsNoTracking()
            .SingleAsync(p => p.Id == id);
    }

    public async Task<int> Create(Product product, CancellationToken cancellationToken)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }

    public async Task Update(Product product, CancellationToken cancellationToken)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(string name, CancellationToken cancellationToken)
    {
        var product = _context.Products.Single(p => p.Name == name);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
    }
}