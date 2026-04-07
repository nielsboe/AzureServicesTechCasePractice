using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Domain.Interfaces;
using Presentation.Controllers;
using Presentation.DTOs;

namespace Tests.Controllers
{
    public class OrderControllerTests
    {
        [Fact]
        public async Task CreateOrder_InvokesSender_ReturnsOk()
        {
            // Arrange
            var mockSender = new Mock<IServiceBusSenderClient>();
            var controller = new OrderController(mockSender.Object);

            var dto = new OrderDTO
            {
                CustomerName = "Jane Doe",
                OrderDate = System.DateTime.UtcNow,
                IsShipped = false,
                TotalOrderPrice = 123
            };

            // Act
            var result = await controller.CreateOrder(dto);

            // Assert
            Assert.IsType<OkResult>(result);
            mockSender.Verify(s => s.Send(dto, "create-order"), Times.Once);
        }

        [Fact]
        public async Task UpdateOrder_InvokesSender_ReturnsOk()
        {
            // Arrange
            var mockSender = new Mock<IServiceBusSenderClient>();
            var controller = new OrderController(mockSender.Object);

            var dto = new OrderDTO
            {
                CustomerName = "Jane Doe",
                OrderDate = System.DateTime.UtcNow,
                IsShipped = true,
                TotalOrderPrice = 99
            };

            // Act
            var result = await controller.UpdateOrder(dto);

            // Assert
            Assert.IsType<OkResult>(result);
            mockSender.Verify(s => s.Send(dto, "update-order"), Times.Once);
        }
    }
}