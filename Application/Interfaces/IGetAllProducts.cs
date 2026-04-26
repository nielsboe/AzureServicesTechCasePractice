using Domain;

namespace Application.Interfaces;

public interface IGetAllProducts
{
    public Task<ICollection<Product>> All();
}
