using Application.Interfaces;
using Domain;

namespace Application.Products.Queries;
public record GetAllProductsQuery;
public class GetAllProductsHandler(IProductRepository productRepository) : IQueryHandler<GetAllProductsQuery, ICollection<Product>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<ICollection<Product>> Handle(GetAllProductsQuery query)
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