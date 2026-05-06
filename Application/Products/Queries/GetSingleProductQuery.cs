using Application.Interfaces;
using Domain;

namespace Application.Products.Queries;
public record GetSingleProductQuery(int productId);
public class GetSingleProductHandler(IProductRepository productRepository) : IQueryHandler<GetSingleProductQuery, Product>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Product> Handle(GetSingleProductQuery query)
    {
        var product = await _productRepository.Get(query.productId);

        return new Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }
}