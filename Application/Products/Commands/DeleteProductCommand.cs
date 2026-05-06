using Application.Interfaces;

namespace Application.Products.Commands;

public record DeleteProductCommand(string productName, CancellationToken cancellationToken);

public class DeleteProductHandler(IProductRepository productRepository) : ICommandHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task Handle(DeleteProductCommand command)
    {
        await _productRepository.Delete(command.productName, command.cancellationToken);
    }
}