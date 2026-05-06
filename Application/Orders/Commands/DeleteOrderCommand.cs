using Application.Interfaces;

namespace Application.Orders.Commands;

public record DeleteOrderCommand(string customerName, CancellationToken cancellationToken);

public class DeleteOrderHandler(IOrderRepository orderRepository) : ICommandHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task Handle(DeleteOrderCommand command)
    {
        await _orderRepository.Delete(command.customerName, command.cancellationToken);
    }
}