using Domain;

namespace Application.Orders.Commands;

public record UpdateOrderCommand(Order order, CancellationToken cancellationToken);