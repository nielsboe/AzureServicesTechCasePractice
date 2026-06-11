using Application.Interfaces;
using Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IServiceBusSenderClient senderClient, IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDTO>> getAllProductsHandler) : Controller
{
    IServiceBusSenderClient _senderClient = senderClient;
    IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDTO>> _getAllProductsHandler = getAllProductsHandler;

    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts(GetAllProductsQuery query)
    {
        return Ok(await _getAllProductsHandler.Handle(query));
    }

    [HttpPut("CreateProduct")]
    public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
    {
        await _senderClient.Send(productDTO, "create-product");
        return Ok();
    }

    [HttpPost("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(ProductDTO productDTO)
    {
        await _senderClient.Send(productDTO, "update-product");
        return Ok();
    }

    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(ProductDTO productDTO)
    {
        await _senderClient.Send(productDTO, "delete-product");
        return Ok();
    }
}