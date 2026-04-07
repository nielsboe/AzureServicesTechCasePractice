using Domain;

namespace Workers.DTOs.Orders;

internal class UpdateOrderDto
{
    public required string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsShipped { get; set; }
    public List<int> ProductIds { get; set; } = new();
    public decimal TotalOrderPrice { get; set; }

    public static Order Map(UpdateOrderDto dto)
    {
        return new Order
        {
            CustomerName = dto.CustomerName,
            OrderDate = dto.OrderDate,
            IsShipped = dto.IsShipped,
            Products = new List<Product>(),
            TotalOrderPrice = dto.TotalOrderPrice
        };
    }
}
