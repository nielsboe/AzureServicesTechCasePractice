using Domain;

namespace Workers.DTOs.Orders;

internal class DeleteOrderDto
{
    public required int InternalOrderId { get; set; }
    public required string CustomerName { get; set; }
    public static Order Map(DeleteOrderDto dto)
    {
        return new Order
        {
            InternalOrderId = dto.InternalOrderId,
            CustomerName = dto.CustomerName
        };
    }
}