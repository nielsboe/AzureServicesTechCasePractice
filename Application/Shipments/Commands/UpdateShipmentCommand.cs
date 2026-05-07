using Application.Interfaces;
using Application.Products.Commands;
using Domain;

namespace Application.Shipments.Commands;

public record UpdateShipmentCommand(Shipment shipment, CancellationToken cancellationToken);
public class UpdateShipmentHandler(IRepository<Shipment> shipmentRepository) : ICommandHandler<UpdateShipmentCommand>
{
    private readonly IRepository<Shipment> _shipmentRepository = shipmentRepository;

    public async Task Handle(UpdateShipmentCommand command)
    {
        await _shipmentRepository.Update(command.shipment, command.cancellationToken);
    }
}