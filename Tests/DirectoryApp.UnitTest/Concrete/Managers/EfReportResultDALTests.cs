using DirectoryApp.DAL.Concrete.EntityFramework.Context;
using DirectoryApp.DAL.Concrete.Managers;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DirectoryApp.UnitTest.Concrete.Managers
{
    public class EfReportResultDALTests
    {
        private MockRepository mockRepository;

        private Mock<ReportContext> mockReportContext;

        public EfReportResultDALTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockReportContext = this.mockRepository.Create<ReportContext>();
        }

        private EfReportResultDAL CreateEfReportResultDAL()
        {
            return new EfReportResultDAL(
                this.mockReportContext.Object);
        }

        [Fact]
        public async Task GetAllAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efReportResultDAL = this.CreateEfReportResultDAL();

            // Act
            var result = await efReportResultDAL.GetAllAsync();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GenerateReportRequest_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efReportResultDAL = this.CreateEfReportResultDAL();

            // Act
            var result = await efReportResultDAL.GenerateReportRequest();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
