using Domain;

namespace Workers.DTOs.Products;

internal class UpdateProductDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }

    public static Product Map(UpdateProductDto dto)
    {
        return new Product()
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
        };
    }
}
