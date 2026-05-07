using Domain;
using Workers.DTOs.Orders;

namespace Workers.DTOs.Shipments;

internal class DeleteShipmentDto
{
    public required int InternalShipmentId { get; set; }
    public int ShipmentId { get; set; }
    public static Shipment Map(DeleteShipmentDto dto)
    {
        return new Shipment
        {
            InternalShipmentId = dto.InternalShipmentId
        };
    }
}