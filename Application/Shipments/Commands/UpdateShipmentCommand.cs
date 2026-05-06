using Application.Interfaces;
using Application.Products.Commands;
using Domain;

namespace Application.Shipments.Commands;

public record UpdateShipmentCommand(Shipment shipment, CancellationToken cancellationToken);
public class UpdateShipmentHandler(IShipmentRepository shipmentRepository) : ICommandHandler<UpdateShipmentCommand>
{
    private readonly IShipmentRepository _shipmentRepository = shipmentRepository;

    public async Task Handle(UpdateShipmentCommand command)
    {
        await _shipmentRepository.Update(command.shipment, command.cancellationToken);
    }
}