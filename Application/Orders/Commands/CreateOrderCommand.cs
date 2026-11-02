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
}https://community.akamai.steamstatic.com/economy/image/i0CoZ81Ui0m-9KwlBY1L_18myuGuq1wfhWSaZgMttyVfPaERSR0Wqmu7LAocGIGz3UqlXOLrxM-vMGmW8VNxu5Tk71ruQBH4jYLf-i5U-fe9V6NhL-aWMXSAxO1_se1gXD2Mkg8mtTuMjobGIyfGPV1PVssnHaMUthC9l9e2Mei25wTajN5EziT_2CodvSxs5ugBWKp2rvDX2Q6QMOc8tI5DeqjzpbB7FA/280x210