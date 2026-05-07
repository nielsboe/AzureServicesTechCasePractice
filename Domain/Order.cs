using Domain.Entity;

namespace Domain;

public class Order : IEntity
{
    public int Id { get; set; }
    public int InternalOrderId { get; set; }
    public required string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsShipped { get; set; }
    public List<Product>? Products { get; set; }
    public decimal TotalOrderPrice { get; set; }
}