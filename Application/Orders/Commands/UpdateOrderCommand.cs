using Application.Interfaces;
using Domain;

namespace Application.Orders.Commands;

public record UpdateOrderCommand(Order order, CancellationToken cancellationToken);

public class UpdateOrderHandler(IOrderRepository orderRepository) : ICommandHandler<UpdateOrderCommand>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task Handle(UpdateOrderCommand command)
    {
        await _orderRepository.Update(command.order, command.cancellationToken);
    }
}