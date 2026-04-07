namespace Domain;

public class Shipment
{
    public int Id { get; set; }
    public int ShipmentId { get; set; }
    public int OrderId { get; set; }
    public string ShipmentAddress { get; set; }
    public List<Product> Products { get; set; }
    public DateTime ShipmentDate { get; set; }
}
