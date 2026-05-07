using Application.Interfaces;
using Domain;

namespace Application.Shipments.Queries;
public record GetAllShipmentsQuery(CancellationToken cancellationToken);
public class GetAllShipmentsHandler(IRepository<Shipment> shipmentRepository) : IQueryHandler<GetAllShipmentsQuery, ICollection<Shipment>>
{
    private readonly IRepository<Shipment> _shipmentRepository = shipmentRepository;

    public async Task<ICollection<Shipment>> Handle(GetAllShipmentsQuery query)
    {
        var shipments = await _shipmentRepository.All(query.cancellationToken);
        return shipments.Select(s => new Shipment
        {
            Products = s.Products,
            ShipmentAddress = s.ShipmentAddress,
            ShipmentDate = s.ShipmentDate
        }).ToList();
    }
}