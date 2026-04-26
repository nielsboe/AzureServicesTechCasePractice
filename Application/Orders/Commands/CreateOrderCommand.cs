using Domain;

namespace Application.Orders.Commands;

public record CreateOrderCommand(Order order, CancellationToken cancellationToken);