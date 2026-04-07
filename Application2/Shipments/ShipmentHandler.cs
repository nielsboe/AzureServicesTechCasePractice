using Domain2;
using Domain2.Interfaces;

namespace Application2.Shipments;

public class ShipmentHandler(IShipmentRepository shipmentRepository) : IShipmentHandler
{
    private readonly IShipmentRepository _shipmentRepository = shipmentRepository;

    public async Task<int> Create(Shipment shipment, CancellationToken cancellationToken)
    {
        // Basic validation
        if (shipment.ShipmentDate <= DateTime.UtcNow)
        {
            throw new ArgumentException("Shipment date must be in the future.");
        }

        // Repository returns bool for create in this project; adapt by returning 0/Id
        var created = _shipmentRepository.CreateShipment(shipment);
        return await Task.FromResult(created ? shipment.Id : 0);
    }

    public async Task Update(Shipment shipment)
    {
        if (shipment.ShipmentDate <= DateTime.UtcNow)
        {
            throw new ArgumentException("Shipment date must be in the future.");
        }

        _shipmentRepository.UpdateShipment(shipment);
        await Task.CompletedTask;
    }

    public async Task Delete(int shipmentId)
    {
        var shipment = _shipmentRepository.GetShipment(shipmentId);
        _shipmentRepository.DeleteShipment(shipment);
        await Task.CompletedTask;
    }
}
