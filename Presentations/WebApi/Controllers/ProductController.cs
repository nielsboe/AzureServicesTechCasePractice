using Application.Interfaces;
using Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IServiceBusSenderClient senderClient, 
    IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDTO>> getAllProductsHandler,
    IQueryHandler<GetSingleProductQuery, ProductDTO> getSingleProductHandler) : Controller
{
    [HttpGet("GetSingleProduct")]
    public async Task<IActionResult> GetSingleProduct(int productId)
    {
        return Ok(await getSingleProductHandler.Handle(new GetSingleProductQuery(productId), CancellationToken.None));
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