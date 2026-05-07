using Domain.Entity;

namespace Domain;

public class Shipment : IEntity
{
    public int Id { get; set; }
    public int InternalShipmentId { get; set; }
    public int OrderId { get; set; }
    public string? ShipmentAddress { get; set; }
    public List<Product>? Products { get; set; }
    public DateTime ShipmentDate { get; set; }
}
