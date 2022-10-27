using DirectoryApp.Core.Entities;
using DirectoryApp.DAL.Concrete.EntityFramework.Context;
using DirectoryApp.DAL.Concrete.Managers;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DirectoryApp.UnitTest.Concrete.Managers
{
    public class EfPersonDALTests
    {
        private MockRepository mockRepository;

        private Mock<PersonContext> mockPersonContext;

        public EfPersonDALTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockPersonContext = this.mockRepository.Create<PersonContext>();
        }

        private EfPersonDAL CreateEfPersonDAL()
        {
            return new EfPersonDAL(
                this.mockPersonContext.Object);
        }

        [Fact]
        public async Task GetAllAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efPersonDAL = this.CreateEfPersonDAL();

            // Act
            var result = await efPersonDAL.GetAllAsync();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetPersonById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efPersonDAL = this.CreateEfPersonDAL();
            string id = null;

            // Act
            var result = await efPersonDAL.GetPersonById(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efPersonDAL = this.CreateEfPersonDAL();
            Person person = null;

            // Act
            var result = await efPersonDAL.Add(
                person);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Save_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efPersonDAL = this.CreateEfPersonDAL();

            // Act
            var result = await efPersonDAL.Save();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efPersonDAL = this.CreateEfPersonDAL();
            Person person = null;

            // Act
            var result = await efPersonDAL.Update(
                person);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var efPersonDAL = this.CreateEfPersonDAL();
            string id = null;

            // Act
            var result = await efPersonDAL.Delete(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
