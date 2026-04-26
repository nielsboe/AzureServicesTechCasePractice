using Application.Products.Commands;

namespace Application.Interfaces;

public interface IProductHandler
{
    Task<int> Create(CreateProductCommand createProductCommand);
    Task Delete(DeleteProductCommand deleteProductCommand);
    Task Update(UpdateProductCommand updateProductCommand);
}