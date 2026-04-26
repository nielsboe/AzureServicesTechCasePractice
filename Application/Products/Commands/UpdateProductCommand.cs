using Domain;

namespace Application.Products.Commands;

public record UpdateProductCommand(Product product, CancellationToken cancellationToken);