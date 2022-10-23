using DirectoryApp.Services.CrudOperations.Data;
using DirectoryApp.Services.CrudOperations.Models;
using DirectoryApp.Services.CrudOperations.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DirectoryApp.UnitTest.Services
{
    public class PersonServiceTests
    {
        private MockRepository mockRepository;

        private Mock<PersonContext> mockPersonContext;

        public PersonServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockPersonContext = this.mockRepository.Create<PersonContext>();
        }

        private PersonService CreateService()
        {
            return new PersonService(
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
        public async Task GetPersonById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string id = null;

            // Act
            var result = await service.GetPersonById(
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
            Person person = null;

            // Act
            var result = await service.Save(
                person);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Person person = null;

            // Act
            var result = await service.Update(
                person);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string id = null;

            // Act
            var result = await service.Delete(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
