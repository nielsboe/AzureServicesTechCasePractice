using Application.Interfaces;
using Domain;

namespace Application.Products.Commands;

public record UpdateProductCommand(Product product, CancellationToken cancellationToken);

public class UpdateProductHandler(IProductRepository productRepository) : ICommandHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task Handle(UpdateProductCommand command)
    {
        // Validate
        if (command.product.Name.Length <= 5)
        {
            throw new ArgumentException("Product name should be at least 5 characters");
        }

        await _productRepository.Update(command.product, command.cancellationToken);
    }
}