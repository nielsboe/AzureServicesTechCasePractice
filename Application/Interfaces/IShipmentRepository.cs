using Domain;

namespace Application.Interfaces;

public interface IShipmentRepository
{
    Task<ICollection<Shipment>> All();
    Shipment Get(int id);
    Task<int> Create(Shipment shipment, CancellationToken cancellationToken);
    Task Update(Shipment shipment, CancellationToken cancellationToken);
    Task Delete(Shipment shipment, CancellationToken cancellationToken);
}