using Application.Interfaces;
using Domain;

namespace Application.Shipments.Commands;

public record DeleteShipmentCommand(int internalShipmentId, CancellationToken cancellationToken);
public class DeleteShipmentHandler(IRepository<Shipment> shipmentRepository) : ICommandHandler<DeleteShipmentCommand>
{
    private readonly IRepository<Shipment> _shipmentRepository = shipmentRepository;

    public async Task Handle(DeleteShipmentCommand command)
    {
        await _shipmentRepository.Delete(command.internalShipmentId, command.cancellationToken);
    }
}