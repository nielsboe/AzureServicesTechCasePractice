using Domain;
using MapsterMapper;
using DataAccessLayer.Interfaces;
using InfrastructureLayer.Data;

namespace InfrastructureLayer.Repositories;

public class InventoryRepository(DataContext context, IMapper mapsterMapper) : IInventoryRepository
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapsterMapper = mapsterMapper;

    public bool ProductExists(int id)
    {
        return _context.Products.Any(p => p.Id == id);
    }

    public ICollection<Product> GetProducts()
    {
        return _context.Products.OrderBy(p => p.Id).ToList();
    }

    public Product GetProduct(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Product not found");
    }

    public bool CreateProduct(ProductDTO productDto)
    {
        var product = _mapsterMapper.Map<Product>(productDto);
        _context.Products.Add(product);
        return Save();
    }

    public bool UpdateProduct(ProductDTO productDto)
    {
        var product = _mapsterMapper.Map<Product>(productDto);
        _context.Products.Update(product);
        return Save();
    }

    public bool DeleteProduct(ProductDTO productDto)
    {
        var product = _mapsterMapper.Map<Product>(productDto);
        _context.Products.Remove(product);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}