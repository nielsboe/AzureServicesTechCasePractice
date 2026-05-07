using Application.Interfaces;
using Domain;

namespace Application.Products.Queries;
public record GetSingleProductQuery(int productId, CancellationToken cancellationToken);
public class GetSingleProductHandler(IRepository<Product> productRepository) : IQueryHandler<GetSingleProductQuery, Product>
{
    private readonly IRepository<Product> _productRepository = productRepository;

    public async Task<Product> Handle(GetSingleProductQuery query)
    {
        var product = await _productRepository.Get(query.productId, query.cancellationToken);
        return new Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }
}