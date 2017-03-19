namespace PhotoArtSystem.Tests.UnitTests.Data.EfDbRepositoryTests
{
    using System.Data.Entity;
    using Common.Constants;
    using Mocks;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.Repositories;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullExceptionWith_ProperMessage_WhenDbContext_IsNull()
        {
            // Arange, Act & Assert
            Assert.That(
                () => new EfDbRepository<DummyGuidClass>(null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.DbContextRequiredExceptionMessage));
        }

        [Test]
        public void NotThrow_WhenArguments_AreValid()
        {
            // Arange
            var mockedDbContext = new Mock<DbContext>();

            // Act & Assert
            Assert.DoesNotThrow(() => new EfDbRepository<DummyGuidClass>(mockedDbContext.Object));
        }
    }
}
