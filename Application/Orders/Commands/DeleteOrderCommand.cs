using Application.Interfaces;
using Domain;

namespace Application.Orders.Commands;

public record DeleteOrderCommand(int internalOrderId, CancellationToken cancellationToken);

public class DeleteOrderHandler(IRepository<Order> orderRepository) : ICommandHandler<DeleteOrderCommand>
{
    private readonly IRepository<Order> _orderRepository = orderRepository;

    public async Task Handle(DeleteOrderCommand command)
    {
        await _orderRepository.Delete(command.internalOrderId, command.cancellationToken);
    }
}