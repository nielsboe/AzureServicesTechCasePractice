namespace Application.Products.Commands;

public record DeleteProductCommand(string productName, CancellationToken cancellationToken);