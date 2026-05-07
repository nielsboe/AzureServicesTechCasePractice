using Domain;
using Workers.DTOs.Orders;

namespace Workers.DTOs.Products;

internal class DeleteProductDto
{
    public required int InternalProductId { get; set; }
    public required string Name { get; set; }
    public static Product Map(DeleteProductDto dto)
    {
        return new Product()
        {
            InternalProductId = dto.InternalProductId,
            Name = dto.Name
        };
    }
}