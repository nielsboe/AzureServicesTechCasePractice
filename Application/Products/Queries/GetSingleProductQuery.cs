using Application.Interfaces;
using Domain;

namespace Application.Products.Queries;
public record GetSingleProductQuery(int productId);
public class GetSingleProductHandler(IRepository<Product> productRepository) : IQueryHandler<GetSingleProductQuery, Product>
{

    public async Task<Product> Handle(GetSingleProductQuery query, CancellationToken cancellationToken)
    {
        var product = await productRepository.Get(query.productId, cancellationToken);
        return new Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }
}