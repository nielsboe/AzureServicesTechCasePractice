using Domain;
using Application.Interfaces;
using Application.Products.Commands;

namespace Application.Products;

public class ProductHandler(IProductRepository inventoryRepository) : IProductHandler
{
    private readonly IProductRepository _productRepository = inventoryRepository;

    public async Task<int> Create(CreateProductCommand createProductCommand)
    {
        // Validate
        if (createProductCommand.product.Name.Length <= 5)
        {
            throw new ArgumentException("Product name should be at least 5 characters");
        }

        return await _productRepository.Create(createProductCommand.product, createProductCommand.cancellationToken);
    }

    public async Task Update(UpdateProductCommand updateProductCommand)
    {
        // Validate
        if (updateProductCommand.product.Name.Length <= 5)
        {
            throw new ArgumentException("Product name should be at least 5 characters");
        }

        await _productRepository.Update(updateProductCommand.product, updateProductCommand.cancellationToken);
    }

    public async Task Delete(DeleteProductCommand deleteProductCommand)
    {
        await _productRepository.Delete(deleteProductCommand.productName, deleteProductCommand.cancellationToken);
    }
} 
