using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Domain.Interfaces;
using Presentation.Controllers;
using Presentation.DTOs;

namespace Tests.Controllers
{
    public class ShippingControllerTests
    {
        [Fact]
        public async Task CreateShipment_InvokesSender_ReturnsOk()
        {
            // Arrange
            var mockSender = new Mock<IServiceBusSenderClient>();
            var controller = new ShippingController(mockSender.Object);

            var dto = new ShipmentDTO
            {
                ShipmentAddress = "123 Main St",
                ShipmentDate = System.DateTime.UtcNow.AddDays(1)
            };

            // Act
            var result = await controller.CreateShipment(dto);

            // Assert
            Assert.IsType<OkResult>(result);
            mockSender.Verify(s => s.Send(dto, "create-shipment"), Times.Once);
        }

        [Fact]
        public async Task GetShipment_InvokesSender_ReturnsOk()
        {
            // Arrange
            var mockSender = new Mock<IServiceBusSenderClient>();
            var controller = new ShippingController(mockSender.Object);

            var dto = new ShipmentDTO { ShipmentAddress = "123 Main", ShipmentDate = System.DateTime.UtcNow.AddDays(1) };

            // Act
            var result = await controller.GetShipment(dto);

            // Assert
            Assert.IsType<OkResult>(result);
            mockSender.Verify(s => s.Send(dto, "get-shipment"), Times.Once);
        }
    }
}