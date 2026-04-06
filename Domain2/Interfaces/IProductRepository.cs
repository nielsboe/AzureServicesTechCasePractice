using Domain2;

namespace Domain2.Interfaces
{
    public interface IProductRepository
    {
        Task<int> Create(Product product, CancellationToken cancellationToken);
        bool DeleteProduct(Product product);
        Product Get(int id);
        ICollection<Product> All();
        bool Exists(int id);
        bool UpdateProduct(Product product);
    }
}