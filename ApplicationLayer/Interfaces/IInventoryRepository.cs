namespace DataAccessLayer.Interfaces;

public interface IInventoryRepository
{
    ICollection<Product> GetProducts();
    Product GetProduct(int id);
    bool ProductExists(int id);
    bool CreateProduct(ProductDTO product);
    bool UpdateProduct(ProductDTO product);
    bool DeleteProduct(ProductDTO product);
    bool Save();
}