using Application.Interfaces;
using Domain;

namespace Application.Products.Commands;

public record CreateProductCommand(Product product, CancellationToken cancellationToken);
public class CreateProductHandler(IProductRepository productRepository) : ICommandHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<int> Handle(CreateProductCommand command)
    {
        // Validate
        if (command.product.Name.Length <= 5)
        {
            throw new ArgumentException("Product name should be at least 5 characters");
        }

        await _productRepository.Create(command.product, command.cancellationToken);

        return command.product.ProductId;
    }
}