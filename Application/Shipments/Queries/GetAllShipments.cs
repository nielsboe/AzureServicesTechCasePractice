using Application.Interfaces;
using Application.Orders.Queries;
using Domain;

namespace Application.Shipments.Queries;
public record GetAllShipmentsQuery;
public class GetAllShipmentsHandler(IRepository<Shipment> shipmentRepository) : IQueryHandler<GetAllShipmentsQuery, ICollection<Shipment>>
{
    public async Task<ICollection<Shipment>> Handle(GetAllShipmentsQuery query, CancellationToken cancellationToken)
    {
        var shipments = await shipmentRepository.All(cancellationToken);
        return shipments.Select(s => new Shipment
        {
            Products = s.Products,
            ShipmentAddress = s.ShipmentAddress,
            ShipmentDate = s.ShipmentDate
        }).ToList();
    }
}