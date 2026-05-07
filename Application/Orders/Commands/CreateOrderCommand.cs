using Application.Interfaces;
using Domain;

namespace Application.Orders.Commands;

public record CreateOrderCommand(Order order, CancellationToken cancellationToken);

public class CreateOrderHandler(IRepository<Order> orderRepository) : ICommandHandler<CreateOrderCommand, int>
{
    private readonly IRepository<Order> _orderRepository = orderRepository;

    public async Task<int> Handle(CreateOrderCommand command)
    {
        await _orderRepository.Create(command.order, command.cancellationToken);

        return command.order.InternalOrderId;
    }
}