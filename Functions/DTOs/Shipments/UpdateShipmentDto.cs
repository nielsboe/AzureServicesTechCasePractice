using Domain2;

namespace Workers.DTOs.Shipments;

internal class UpdateShipmentDto
{
    public required string ShipmentAddress { get; set; }
    public List<int> ProductIds { get; set; } = new();
    public DateTime ShipmentDate { get; set; }

    public static Shipment Map(UpdateShipmentDto dto)
    {
        return new Shipment
        {
            ShipmentAddress = dto.ShipmentAddress,
            Products = new List<Product>(),
            ShipmentDate = dto.ShipmentDate
        };
    }
}
