using DirectoryApp.BLL.Concrete;
using DirectoryApp.Core.Entities;
using DirectoryApp.DAL.Abstract;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DirectoryApp.UnitTest.Concrete
{
    public class PersonManagerTests
    {
        private MockRepository mockRepository;

        private Mock<IPersonDAL> mockPersonDAL;

        public PersonManagerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockPersonDAL = this.mockRepository.Create<IPersonDAL>();
        }

        private PersonManager CreateManager()
        {
            return new PersonManager(
                this.mockPersonDAL.Object);
        }

        [Fact]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            string id = null;

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
        public async Task GetPersonById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            string id = null;

            // Act
            var result = await manager.GetPersonById(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            Person person = null;

            // Act
            var result = await manager.Add(
                person);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            Person person = null;

            // Act
            var result = await manager.Update(
                person);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
