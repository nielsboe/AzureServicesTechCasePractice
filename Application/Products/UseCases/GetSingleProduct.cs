using Application.Interfaces;
using Domain;

namespace Application.Products.UseCases;

public class GetSingleProduct
{
    private readonly IProductRepository _productRepository;


    public GetSingleProduct(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> GetSingleProductById(int productId, CancellationToken cancellationToken)
    {
        var product = await _productRepository.Get(productId);

        return new Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }
}