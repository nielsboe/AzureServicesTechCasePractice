using Domain;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task<int> Create(Product product, CancellationToken cancellationToken);
    Task Delete(string name);
    Task<Product> Get(int id);
    Task<ICollection<Product>>  All();
    Task Update(Product product);
}