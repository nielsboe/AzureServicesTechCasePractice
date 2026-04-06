using Domain2;
using Domain2.Interfaces;

namespace Application2.Products;

public class ProductHandler(IProductRepository inventoryRepository) : IProductHandler
{
    private readonly IProductRepository _inventoryRepository = inventoryRepository;

    public async Task<int> Create(Product product, CancellationToken cancellationToken)
    {
        // Validate
        if (product.Name.Length <= 5)
        {
            throw new ArgumentException("Product name should be at least 5 characters");
        }

        return await _inventoryRepository.Create(product, cancellationToken);
    }

    public async Task Update(Product product)
    {
        // Validate
        if (product.Name.Length <= 5)
        {
            throw new ArgumentException("Product name should be at least 5 characters");
        }

        await _inventoryRepository.Update(product);
    }

    public async Task Delete(string name)
    {
        await _inventoryRepository.Delete(name);
    }
} 
