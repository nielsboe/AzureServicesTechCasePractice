namespace Presentation.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public int InternalProductId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
}