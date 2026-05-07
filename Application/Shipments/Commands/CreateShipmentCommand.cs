using Application.Interfaces;
using Domain;

namespace Application.Shipments.Commands;

public record CreateShipmentCommand(Shipment shipment, CancellationToken cancellationToken);
public class CreateShipmentHandler(IRepository<Shipment> shipmentRepository) : ICommandHandler<CreateShipmentCommand, int>
{
    private readonly IRepository<Shipment> _shipmentRepository = shipmentRepository;

    public async Task<int> Handle(CreateShipmentCommand command)
    {
        if (command.shipment.ShipmentDate <= DateTime.UtcNow)
        {
            throw new ArgumentException("Shipment date must be in the future.");
        }

        await _shipmentRepository.Create(command.shipment, command.cancellationToken);

        return command.shipment.InternalShipmentId;
    }
}