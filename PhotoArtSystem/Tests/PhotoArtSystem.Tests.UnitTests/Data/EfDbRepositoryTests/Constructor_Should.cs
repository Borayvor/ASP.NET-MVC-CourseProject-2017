namespace PhotoArtSystem.Tests.UnitTests.Data.EfDbRepositoryTests
{
    using Common.Constants;
    using Mocks;
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
                () => new EfDbRepository<DummyClass>(null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.EfDbRepositoryConstructorExceptionMessage));
        }
    }
}
