using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Domain;
using Domain.Interfaces;
using Presentation.Controllers;
using Application.Products;
using Presentation.DTOs;

namespace Tests.Controllers
{
    public class ProductControllerTests
    {
        [Fact]
        public async Task GetProducts_CallsHandler_ReturnsOkObjectResult()
        {
            // Arrange
            var mockSender = new Mock<IServiceBusSenderClient>();
            var mockHandler = new Mock<IProductHandler>();

            var products = new List<Product>
            {
                new Product { Name = "Test-1", Description = "d", Price = 10m },
                new Product { Name = "Test-2", Description = "d2", Price = 20m }
            };

            mockHandler
                .Setup(h => h.GetAll(It.IsAny<CancellationToken>()))
                .ReturnsAsync(products);

            var controller = new ProductController(mockSender.Object, mockHandler.Object);

            // Act
            var result = await controller.GetProducts(CancellationToken.None);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
            Assert.Same(products, ok.Value);
            mockHandler.Verify(h => h.GetAll(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateProduct_SendsMessage_ReturnsOk()
        {
            // Arrange
            var mockSender = new Mock<IServiceBusSenderClient>();
            var mockHandler = new Mock<IProductHandler>();
            var controller = new ProductController(mockSender.Object, mockHandler.Object);

            var dto = new ProductDTO
            {
                Name = "Created",
                Description = "desc",
                Price = 1m
            };

            // Act
            var result = await controller.CreateProduct(dto);

            // Assert
            Assert.IsType<OkResult>(result);
            mockSender.Verify(s => s.Send(dto, "create-product"), Times.Once);
        }
    }
}