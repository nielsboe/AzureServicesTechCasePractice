using Application.Interfaces;
using Domain;

namespace Application.Orders.Commands;

public record UpdateOrderCommand(Order order, CancellationToken cancellationToken);

public class UpdateOrderHandler(IRepository<Order> orderRepository) : ICommandHandler<UpdateOrderCommand>
{
    private readonly IRepository<Order> _orderRepository = orderRepository;

    public async Task Handle(UpdateOrderCommand command)
    {
        await _orderRepository.Update(command.order, command.cancellationToken);
    }
}