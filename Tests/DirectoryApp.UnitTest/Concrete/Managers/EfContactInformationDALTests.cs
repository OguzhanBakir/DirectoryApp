using DirectoryApp.Core.Entities;
using DirectoryApp.DAL.Concrete.EntityFramework.Context;
using DirectoryApp.DAL.Concrete.Managers;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DirectoryApp.UnitTest.Concrete.Managers
{
    public class EfContactInformationDALTests
    {
        private MockRepository mockRepository;

        private Mock<PersonContext> mockPersonContext;

        public EfContactInformationDALTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockPersonContext = this.mockRepository.Create<PersonContext>();
        }

        private EfContactInformationDAL CreateEfContactInformationDAL()
        {
            return new EfContactInformationDAL(
                this.mockPersonContext.Object);
        }

        [Fact]
        public async Task GetAllAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efContactInformationDAL = this.CreateEfContactInformationDAL();

            // Act
            var result = await efContactInformationDAL.GetAllAsync();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetContactInformationListByPersonId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efContactInformationDAL = this.CreateEfContactInformationDAL();
            Guid id = default(global::System.Guid);

            // Act
            var result = await efContactInformationDAL.GetContactInformationListByPersonId(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetContactInformationByPersonId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efContactInformationDAL = this.CreateEfContactInformationDAL();
            Guid id = default(global::System.Guid);

            // Act
            var result = await efContactInformationDAL.GetContactInformationByPersonId(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efContactInformationDAL = this.CreateEfContactInformationDAL();
            ContactInformation contact = null;

            // Act
            var result = await efContactInformationDAL.Add(
                contact);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Save_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efContactInformationDAL = this.CreateEfContactInformationDAL();

            // Act
            var result = await efContactInformationDAL.Save();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efContactInformationDAL = this.CreateEfContactInformationDAL();
            ContactInformation contact = null;

            // Act
            var result = await efContactInformationDAL.Update(
                contact);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efContactInformationDAL = this.CreateEfContactInformationDAL();
            int id = 0;

            // Act
            var result = await efContactInformationDAL.Delete(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetByInformationValue_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efContactInformationDAL = this.CreateEfContactInformationDAL();
            string value = null;
            string personId = null;

            // Act
            var result = await efContactInformationDAL.GetByInformationValue(
                value,
                personId);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
