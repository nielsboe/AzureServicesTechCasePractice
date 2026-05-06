using Application.Interfaces;
using Domain;

namespace Application.Shipments.Queries;
public record GetSingleShipmentQuery(int shipmentId);
public class GetSingleShipmentHandler(IShipmentRepository shipmentRepository) : IQueryHandler<GetSingleShipmentQuery, Shipment>
{
    private readonly IShipmentRepository _shipmentRepository = shipmentRepository;

    public async Task<Shipment> Handle(GetSingleShipmentQuery query)
    {
        var shipment = await _shipmentRepository.Get(query.shipmentId);
        return new Shipment()
        {
            Products = shipment.Products,
            ShipmentAddress = shipment.ShipmentAddress,
            ShipmentDate = shipment.ShipmentDate
        };
    }
}