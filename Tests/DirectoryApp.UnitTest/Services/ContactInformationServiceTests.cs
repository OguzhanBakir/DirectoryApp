using DirectoryApp.Services.CrudOperations.Data;
using DirectoryApp.Services.CrudOperations.Models;
using DirectoryApp.Services.CrudOperations.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DirectoryApp.UnitTest.Services
{
    public class ContactInformationServiceTests
    {
        private MockRepository mockRepository;

        private Mock<PersonContext> mockPersonContext;

        public ContactInformationServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockPersonContext = this.mockRepository.Create<PersonContext>();
        }

        private ContactInformationService CreateService()
        {
            return new ContactInformationService(
                this.mockPersonContext.Object);
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
        public async Task GetContactListInformationByPersonId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            var result = await service.GetContactListInformationByPersonId(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetContactInformationByPersonId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            var result = await service.GetContactInformationByPersonId(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Save_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            ContactInformation contact = null;

            // Act
            var result = await service.Save(
                contact);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            ContactInformation contact = null;

            // Act
            var result = await service.Update(
                contact);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;

            // Act
            var result = await service.Delete(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetByInformationValue_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string value = null;
            string personId = null;

            // Act
            var result = await service.GetByInformationValue(
                value,
                personId);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
