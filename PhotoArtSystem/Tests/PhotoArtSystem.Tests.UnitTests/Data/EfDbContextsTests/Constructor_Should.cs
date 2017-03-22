namespace PhotoArtSystem.Tests.UnitTests.Data.EfDbContextsTests
{
    using Common.Constants;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullExceptionWith_ProperMessage_WhenDbContext_IsNull()
        {
            // Arange, Act & Assert
            Assert.That(
                () => new EfDbContextSaveChanges(null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.DbContextRequiredExceptionMessage));
        }
    }
}
