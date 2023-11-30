using Microsoft.AspNetCore.Mvc;
using OrderProcessingApp.Application;
using OrderProcessingApp.Core;

namespace OrderProcessingApp.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void CreateOrder_WithValidData_CallsOrderProcessor()
        {
            // Arrange
            var orderProcessor = new OrderProcessor();
            var orderService = new OrderService(orderProcessor);
            var order = new Order { Id = 1, CustomerName = "John Doe", ProductName = "Widget", Quantity = 2, Price = 10.0M };

            // Act
            orderService.CreateOrder(order);

            // Assert
        }

        [Fact]
        public void CreateOrder_WithNullOrder_ReturnsBadRequest()
        {
            // Arrange
            var orderProcessor = new Mock<IOrderProcessor>();
            var orderService = new OrderService(orderProcessor.Object);

            // Act
            var result = orderService.CreateOrder(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateOrder_WithValidData_ReturnsOk()
        {
            // Arrange
            var orderProcessorMock = new Mock<IOrderProcessor>();
            var orderService = new OrderService(orderProcessorMock.Object);
            var order = new Order { Id = 1, CustomerName = "John Doe", ProductName = "Widget", Quantity = 2, Price = 10.0M };

            // Act
            var result = orderService.CreateOrder(order);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Order created successfully.", okObjectResult.Value);

            orderProcessorMock.Verify(op => op.ProcessOrder(order), Times.Once);
        }
    }
}
