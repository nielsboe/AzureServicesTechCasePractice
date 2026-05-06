using Application.Interfaces;
using Domain;

namespace Application.Shipments.Queries;
public record GetAllShipmentsQuery;
public class GetAllShipmentsHandler(IShipmentRepository shipmentRepository) : IQueryHandler<GetAllShipmentsQuery, ICollection<Shipment>>
{
    private readonly IShipmentRepository _shipmentRepository = shipmentRepository;

    public async Task<ICollection<Shipment>> Handle(GetAllShipmentsQuery query)
    {
        var shipments = await _shipmentRepository.All();

        return shipments.Select(s => new Shipment
        {
            Products = s.Products,
            ShipmentAddress = s.ShipmentAddress,
            ShipmentDate = s.ShipmentDate
        }).ToList();
    }
}