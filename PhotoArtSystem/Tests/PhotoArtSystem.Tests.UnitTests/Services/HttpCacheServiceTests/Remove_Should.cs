namespace PhotoArtSystem.Tests.UnitTests.Services.HttpCacheServiceTests
{
    using Common.Constants;
    using NUnit.Framework;
    using PhotoArtSystem.Services.Web;

    [TestFixture]
    public class Remove_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_ItemName_IsNull()
        {
            // Arange
            var service = new HttpCacheService();

            // Act & Assert
            Assert.That(
                () => service.Remove(null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.ItemNameRequiredExceptionMessage));
        }
    }
}
