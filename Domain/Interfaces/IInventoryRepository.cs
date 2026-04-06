namespace Domain.Interfaces;

public interface IInventoryRepository
{
    ICollection<Product> GetProducts();
    Product GetProduct(int id);
    bool ProductExists(int id);
    bool Save();
}