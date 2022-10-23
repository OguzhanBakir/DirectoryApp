using DirectoryApp.Services.Report.Data;
using DirectoryApp.Services.Report.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DirectoryApp.UnitTest.Services
{
    public class ReportResultServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ReportContext> mockReportContext;
        private Mock<RabbitMQPublisher> mockRabbitMQPublisher;

        public ReportResultServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockReportContext = this.mockRepository.Create<ReportContext>();
            this.mockRabbitMQPublisher = this.mockRepository.Create<RabbitMQPublisher>();
        }

        private ReportResultService CreateService()
        {
            return new ReportResultService(
                this.mockReportContext.Object,
                this.mockRabbitMQPublisher.Object);
        }

        [Fact]
        public async Task GetAllAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GenerateReportRequest_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = await service.GenerateReportRequest();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
