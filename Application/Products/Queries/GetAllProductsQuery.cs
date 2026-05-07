using Application.Interfaces;
using Domain;

namespace Application.Products.Queries;
public record GetAllProductsQuery(CancellationToken cancellationToken);
public class GetAllProductsHandler(IRepository<Product> productRepository) : IQueryHandler<GetAllProductsQuery, ICollection<Product>>
{
    private readonly IRepository<Product> _productRepository = productRepository;

    public async Task<ICollection<Product>> Handle(GetAllProductsQuery query)
    {
        var products = await _productRepository.All(query.cancellationToken);

        return products.Select(p => new Product
        {
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        }).ToList();
    }
}