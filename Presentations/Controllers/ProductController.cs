using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IServiceBusSenderClient _senderClient;
    private IProductHandler _productHandler;

    public ProductController(IServiceBusSenderClient senderClient, IProductHandler productHandler)
    {
        _senderClient = senderClient;
        _productHandler = productHandler;
    }

    [HttpGet("GetProducts")]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        return Ok(await _productHandler.GetAll(cancellationToken));
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