using DirectoryApp.BLL.Concrete;
using DirectoryApp.Core.Utilities.RabbitMQ;
using DirectoryApp.DAL.Abstract;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DirectoryApp.UnitTest.Concrete
{
    public class ReportResultManagerTests
    {
        private MockRepository mockRepository;

        private Mock<IReportResultDAL> mockReportResultDAL;
        private Mock<RabbitMQPublisher> mockRabbitMQPublisher;

        public ReportResultManagerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockReportResultDAL = this.mockRepository.Create<IReportResultDAL>();
            this.mockRabbitMQPublisher = this.mockRepository.Create<RabbitMQPublisher>();
        }

        private ReportResultManager CreateManager()
        {
            return new ReportResultManager(
                this.mockReportResultDAL.Object,
                this.mockRabbitMQPublisher.Object);
        }

        [Fact]
        public async Task GenerateReportRequest_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();

            // Act
            var result = await manager.GenerateReportRequest();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetAllAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();

            // Act
            var result = await manager.GetAllAsync();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
