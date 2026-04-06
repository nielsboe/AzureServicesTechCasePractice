using Domain2;

namespace Application2.Shipments;

public interface IShipmentHandler
{
    Task<int> Create(Shipment shipment, CancellationToken cancellationToken);
    Task Update(Shipment shipment);
    Task Delete(int shipmentId);
}
