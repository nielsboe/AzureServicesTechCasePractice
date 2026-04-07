using Domain;
using Domain.Interfaces;

namespace Application.Products;

public class ProductHandler(IProductRepository inventoryRepository) : IProductHandler
{
    private readonly IProductRepository _productRepository = inventoryRepository;

    public async Task<ICollection<Product>> GetAll(CancellationToken cancellationToken)
    {
        var products = await _productRepository.All();
        return products;
    }

    public async Task<int> Create(Product product, CancellationToken cancellationToken)
    {
        // Validate
        if (product.Name.Length <= 5)
        {
            throw new ArgumentException("Product name should be at least 5 characters");
        }

        return await _productRepository.Create(product, cancellationToken);
    }

    public async Task Update(Product product)
    {
        // Validate
        if (product.Name.Length <= 5)
        {
            throw new ArgumentException("Product name should be at least 5 characters");
        }

        await _productRepository.Update(product);
    }

    public async Task Delete(string name)
    {
        await _productRepository.Delete(name);
    }
} 
