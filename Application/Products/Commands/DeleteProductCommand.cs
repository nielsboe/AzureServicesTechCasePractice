using Application.Interfaces;
using Domain;

namespace Application.Products.Commands;

public record DeleteProductCommand(int internalProductId, CancellationToken cancellationToken);

public class DeleteProductHandler(IRepository<Product> productRepository) : ICommandHandler<DeleteProductCommand>
{
    private readonly IRepository<Product> _productRepository = productRepository;

    public async Task Handle(DeleteProductCommand command)
    {
        await _productRepository.Delete(command.internalProductId, command.cancellationToken);
    }
}