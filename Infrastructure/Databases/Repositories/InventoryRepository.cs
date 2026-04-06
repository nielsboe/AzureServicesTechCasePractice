using Domain2;
using Domain2.Interfaces;

namespace Infrastructure.Databases.Repositories;

public class InventoryRepository(DataContext context) : IProductRepository
{
    private readonly DataContext _context = context;

    public bool Exists(int id)
    {
        return _context.Products.Any(p => p.Id == id);
    }

    public ICollection<Product> All()
    {
        return _context.Products.OrderBy(p => p.Id).ToList();
    }

    public Product Get(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Product not found");
    }

    public async Task<int> Create(Product product, CancellationToken cancellationToken)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        _context.SaveChanges();

        return product.Id;
    }

    public async Task Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public async Task Delete(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }
}