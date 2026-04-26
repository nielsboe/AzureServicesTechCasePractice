using Application.Interfaces;
using Domain;

namespace Application.Products.UseCases;

internal class GetAllProducts
{
    private readonly IProductRepository _productRepository;


    public GetAllProducts(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ICollection<Product>> GetAndMapAllProducts(CancellationToken cancellationToken)
    {
        var products = await _productRepository.All();

        return products.Select(p => new Product
        {
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        }).ToList();
    }
}