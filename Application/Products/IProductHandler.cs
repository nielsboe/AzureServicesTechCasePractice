using Domain;

namespace Application.Products;

public interface IProductHandler
{
    public Task<ICollection<Product>> GetAll(CancellationToken cancellationToken);
    Task<int> Create(Product product, CancellationToken cancellationToken);
    Task Delete(string name);
    Task Update(Product product);
}