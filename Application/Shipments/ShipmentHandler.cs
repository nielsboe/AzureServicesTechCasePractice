using Application.Interfaces;
using Domain;
using Application.Shipments.Commands;

namespace Application.Shipments;

public class ShipmentHandler(IShipmentRepository shipmentRepository) : IShipmentHandler
{
    private readonly IShipmentRepository _shipmentRepository = shipmentRepository;

    public async Task<int> Create(CreateShipmentCommand createShipmentCommand)
    {
        if (createShipmentCommand.shipment.ShipmentDate <= DateTime.UtcNow)
        {
            throw new ArgumentException("Shipment date must be in the future.");
        }

        await _shipmentRepository.Create(createShipmentCommand.shipment, createShipmentCommand.cancellationToken);
        return createShipmentCommand.shipment.Id;
    }

    public async Task Update(UpdateShipmentCommand updateShipmentCommand)
    {
        if (updateShipmentCommand.shipment.ShipmentDate <= DateTime.UtcNow)
        {
            throw new ArgumentException("Shipment date must be in the future.");
        }

        await _shipmentRepository.Update(updateShipmentCommand.shipment, updateShipmentCommand.cancellationToken);
    }

    public async Task Delete(DeleteShipmentCommand deleteShipmentCommand)
    {
        var shipment = _shipmentRepository.Get(deleteShipmentCommand.shipmentId);
        await _shipmentRepository.Delete(shipment, deleteShipmentCommand.cancellationToken);
    }
}
