using Domain;

namespace Application.Interfaces;

public interface IProductRepository
{
    Task<int> Create(Product product, CancellationToken cancellationToken);
    Task Delete(string productName, CancellationToken cancellationToken);
    Task<Product> Get(int id);
    Task<ICollection<Product>>  All();
    Task Update(Product product, CancellationToken cancellationToken);
}