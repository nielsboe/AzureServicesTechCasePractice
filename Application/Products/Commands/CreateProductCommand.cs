using Domain;

namespace Application.Products.Commands;

public record CreateProductCommand(Product product, CancellationToken cancellationToken);