using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IServiceBusSenderClient senderClient, IProductHandler productHandler, IGetAllProducts getAllProducts) : Controller
{
    IServiceBusSenderClient _senderClient = senderClient;
    IGetAllProducts _getAllProducts = getAllProducts;

    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
    {
        return Ok(await _getAllProducts.All());
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