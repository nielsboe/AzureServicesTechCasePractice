using Application.Interfaces;
using Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IServiceBusSenderClient senderClient, IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDTO>> getAllProductsHandler) : Controller
{
    [HttpGet("GetProduct")]
    public async Task<IActionResult> GetSingleProduct(ProductDTO productDTO)
    {
        await senderClient.Send(productDTO, "get-product");
        return Ok();
    }

    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
    {
        return Ok(await getAllProductsHandler.Handle(new GetAllProductsQuery(), cancellationToken));
    }

    [HttpPut("CreateProduct")]
    public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
    {
        await senderClient.Send(productDTO, "create-product");
        return Ok();
    }

    [HttpPost("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(ProductDTO productDTO)
    {
        await senderClient.Send(productDTO, "update-product");
        return Ok();
    }

    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(ProductDTO productDTO)
    {
        await senderClient.Send(productDTO, "delete-product");
        return Ok();
    }
}