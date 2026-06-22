using Application.Interfaces;
using Domain;

namespace Application.Shipments.Queries;
public record GetSingleShipmentQuery(int shipmentId, CancellationToken cancellationToken);
public class GetSingleShipmentHandler(IRepository<Shipment> shipmentRepository) : IQueryHandler<GetSingleShipmentQuery, Shipment>
{
    public async Task<Shipment> Handle(GetSingleShipmentQuery query, CancellationToken cancellationToken)
    {
        var shipment = await shipmentRepository.Get(query.shipmentId, cancellationToken);
        return new Shipment()
        {
            Products = shipment.Products,
            ShipmentAddress = shipment.ShipmentAddress,
            ShipmentDate = shipment.ShipmentDate
        };
    }
}