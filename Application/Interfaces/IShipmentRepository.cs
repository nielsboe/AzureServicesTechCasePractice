using Domain;

namespace Application.Interfaces;

public interface IShipmentRepository
{
    Task<ICollection<Shipment>> All();
    Task<Shipment> Get(int id);
    Task<int> Create(Shipment shipment, CancellationToken cancellationToken);
    Task Update(Shipment shipment, CancellationToken cancellationToken);
    Task Delete(int shipmentId, CancellationToken cancellationToken);
}