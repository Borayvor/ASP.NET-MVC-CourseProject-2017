namespace PhotoArtSystem.Tests.UnitTests.Data.EfDbContextsTests
{
    using System.Data.Entity;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;

    [TestFixture]
    public class Save_Should
    {
        [Test]
        public void CallOnce_DbContext_SaveChanges()
        {
            // Arange
            var mockedDbContext = new Mock<DbContext>();
            mockedDbContext.Setup(x => x.SaveChanges()).Verifiable();

            var context = new EfDbContextSaveChanges(mockedDbContext.Object);

            // Act
            context.Save();

            // Assert
            mockedDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
