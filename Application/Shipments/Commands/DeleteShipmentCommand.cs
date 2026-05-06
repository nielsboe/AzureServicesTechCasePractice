using Application.Interfaces;
using Application.Products.Commands;

namespace Application.Shipments.Commands;

public record DeleteShipmentCommand(int shipmentId, CancellationToken cancellationToken);
public class DeleteShipmentHandler(IShipmentRepository shipmentRepository) : ICommandHandler<DeleteShipmentCommand>
{
    private readonly IShipmentRepository _shipmentRepository = shipmentRepository;

    public async Task Handle(DeleteShipmentCommand command)
    {
        await _shipmentRepository.Delete(command.shipmentId, command.cancellationToken);
    }
}