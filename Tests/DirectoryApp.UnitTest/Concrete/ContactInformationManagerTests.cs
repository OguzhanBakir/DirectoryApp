using DirectoryApp.BLL.Concrete;
using DirectoryApp.Core.Entities;
using DirectoryApp.DAL.Abstract;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DirectoryApp.UnitTest.Concrete
{
    public class ContactInformationManagerTests
    {
        private MockRepository mockRepository;

        private Mock<IContactInformationDAL> mockContactInformationDAL;

        public ContactInformationManagerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockContactInformationDAL = this.mockRepository.Create<IContactInformationDAL>();
        }

        private ContactInformationManager CreateManager()
        {
            return new ContactInformationManager(
                this.mockContactInformationDAL.Object);
        }

        [Fact]
        public async Task Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            ContactInformation contactInformation = null;

            // Act
            var result = await manager.Add(
                contactInformation);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            int id = 0;

            // Act
            var result = await manager.Delete(
                id);

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

        [Fact]
        public async Task GetByInformationValue_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            string value = null;
            string personId = null;

            // Act
            var result = await manager.GetByInformationValue(
                value,
                personId);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetContactInformationByPersonId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            Guid id = default(global::System.Guid);

            // Act
            var result = await manager.GetContactInformationByPersonId(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetContactInformationListByPersonId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            Guid id = default(global::System.Guid);

            // Act
            var result = await manager.GetContactInformationListByPersonId(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            ContactInformation contactInformation = null;

            // Act
            var result = await manager.Update(
                contactInformation);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
