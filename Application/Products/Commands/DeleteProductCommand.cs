namespace Application.Products.Commands;

public record DeleteProductCommand(int productId, CancellationToken cancellationToken);