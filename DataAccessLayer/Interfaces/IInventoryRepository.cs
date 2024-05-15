using Domain;

namespace DataAccessLayer.Interfaces;

public interface IInventoryRepository
{
    ICollection<Product> GetProducts();
    Product GetProduct(int id);
    bool ProductExists(int id);
    bool CreateProduct(Product product);
    bool UpdateProduct(Product product);
    bool DeleteProduct(Product product);
    bool Save();
}