using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public async Task Create_InputUserInstance_CalledAddAsyncMethodOfDBSetWithUserInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DBContext>().Options;
            var mockContext = new Mock<DBContext>(opt);
            var mockDbSet = new Mock<DbSet<User>>();
            mockContext
                .Setup(context => context.Set<User>())
                .Returns(mockDbSet.Object);
            var repository = new UserRepository(mockContext.Object);
            User expectedUser = new Mock<User>().Object;

            // Act
            await repository.CreateAsync(expectedUser);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.AddAsync(expectedUser, default), Times.Once());
        }
        [Fact]
        public async Task Update_InputUserInstance_CalledUpdateMethodOfDBSetWithUserInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DBContext>().Options;
            var mockContext = new Mock<DBContext>(opt);
            var mockDbSet = new Mock<DbSet<User>>();
            mockContext
                .Setup(context => context.Set<User>())
                .Returns(mockDbSet.Object);
            var repository = new UserRepository(mockContext.Object);
            User expectedUser = new Mock<User>().Object;

            // Act
            await repository.UpdateAsync(expectedUser);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Update(expectedUser), Times.Once());
        }

        [Fact]
        public async Task Delete_InputUserId_CalledRemoveMethodOfDBSetWithUserInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DBContext>().Options;
            var mockContext = new Mock<DBContext>(opt);
            var mockDbSet = new Mock<DbSet<User>>();
            var expectedUser = new Mock<User>().Object;
            
            mockContext
                .Setup(context => context.Set<User>())
                .Returns(mockDbSet.Object);
            
            mockDbSet
                .Setup(s => s.FindAsync(expectedUser.Id))
                .ReturnsAsync(expectedUser);

            var repository = new UserRepository(mockContext.Object);

            // Act
            await repository.DeleteAsync(expectedUser.Id);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Remove(expectedUser), Times.Once());
        }
    }
}
