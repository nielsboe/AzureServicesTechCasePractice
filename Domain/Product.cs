using Domain.Entity;

namespace Domain;

public class Product : IEntity
{
    public int Id { get; set; }
    public int InternalProductId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}