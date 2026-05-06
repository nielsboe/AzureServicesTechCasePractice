using Application.Interfaces;
using Domain;

namespace Application.Orders.Commands;

public record CreateOrderCommand(Order order, CancellationToken cancellationToken);

public class CreateOrderHandler(IOrderRepository orderRepository) : ICommandHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<int> Handle(CreateOrderCommand command)
    {
        await _orderRepository.Create(command.order, command.cancellationToken);

        return command.order.OrderId;
    }
}