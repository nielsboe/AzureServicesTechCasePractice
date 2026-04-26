namespace Application.Orders.Commands;

public record DeleteOrderCommand(string customerName, CancellationToken cancellationToken);