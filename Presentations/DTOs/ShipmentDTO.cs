namespace Presentation.DTOs;

public class ShipmentDTO
{
    public int Id { get; set; }
    public int InternalShipmentId { get; set; }
    public int OrderId { get; set; }
    public required string ShipmentAddress { get; set; }
    public required List<ProductDTO> Products { get; set; }
    public DateTime ShipmentDate { get; set; }
}