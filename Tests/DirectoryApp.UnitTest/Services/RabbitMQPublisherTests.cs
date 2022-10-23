using DirectoryApp.Services.Report.Services;
using DirectoryApp.Services.Report.Shared;
using Moq;
using System;
using Xunit;

namespace DirectoryApp.UnitTest.Services
{
    public class RabbitMQPublisherTests
    {
        private MockRepository mockRepository;

        private Mock<RabbitMQClientService> mockRabbitMQClientService;

        public RabbitMQPublisherTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockRabbitMQClientService = this.mockRepository.Create<RabbitMQClientService>();
        }

        private RabbitMQPublisher CreateRabbitMQPublisher()
        {
            return new RabbitMQPublisher(
                this.mockRabbitMQClientService.Object);
        }

        [Fact]
        public void Publish_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rabbitMQPublisher = this.CreateRabbitMQPublisher();
            CreateExcelMessage createExcelMessage = null;

            // Act
            rabbitMQPublisher.Publish(
                createExcelMessage);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
