using Application.Interfaces;
using Application.Orders.Queries;
using Domain;

namespace Application.Products.Queries;

public record GetAllProductsQuery;
public class GetAllProductsHandler(IRepository<Product> productRepository) : IQueryHandler<GetAllProductsQuery, ICollection<Product>>
{
    public async Task<ICollection<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await productRepository.All(cancellationToken);

        return products.Select(p => new Product
        {
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        }).ToList();
    }
}