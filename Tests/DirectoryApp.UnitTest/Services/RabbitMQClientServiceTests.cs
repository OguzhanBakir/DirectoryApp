using DirectoryApp.Services.Report.Services;
using Microsoft.Extensions.Logging;
using Moq;
using RabbitMQ.Client;
using System;
using Xunit;

namespace DirectoryApp.UnitTest.Services
{
    public class RabbitMQClientServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ConnectionFactory> mockConnectionFactory;
        private Mock<ILogger<RabbitMQClientService>> mockLogger;

        public RabbitMQClientServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockConnectionFactory = this.mockRepository.Create<ConnectionFactory>();
            this.mockLogger = this.mockRepository.Create<ILogger<RabbitMQClientService>>();
        }

        private RabbitMQClientService CreateService()
        {
            return new RabbitMQClientService(
                this.mockConnectionFactory.Object,
                this.mockLogger.Object);
        }

        [Fact]
        public void Connect_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = service.Connect();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            service.Dispose();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
