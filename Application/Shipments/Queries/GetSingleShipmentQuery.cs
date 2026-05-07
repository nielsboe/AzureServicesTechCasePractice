using Application.Interfaces;
using Domain;

namespace Application.Shipments.Queries;
public record GetSingleShipmentQuery(int shipmentId, CancellationToken cancellationToken);
public class GetSingleShipmentHandler(IRepository<Shipment> shipmentRepository) : IQueryHandler<GetSingleShipmentQuery, Shipment>
{
    private readonly IRepository<Shipment> _shipmentRepository = shipmentRepository;

    public async Task<Shipment> Handle(GetSingleShipmentQuery query)
    {
        var shipment = await _shipmentRepository.Get(query.shipmentId, query.cancellationToken);
        return new Shipment()
        {
            Products = shipment.Products,
            ShipmentAddress = shipment.ShipmentAddress,
            ShipmentDate = shipment.ShipmentDate
        };
    }
}