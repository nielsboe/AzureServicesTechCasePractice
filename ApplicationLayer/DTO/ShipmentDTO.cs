namespace Domain;

public class ShipmentDTO
{
    public int Id { get; set; }
    public int ShipmentId { get; set; }
    public int OrderId { get; set; }
    public string ShipmentAddress { get; set; }
    public List<ProductDTO> Products { get; set; }
    public DateTime ShipmentDate { get; set; }
}
