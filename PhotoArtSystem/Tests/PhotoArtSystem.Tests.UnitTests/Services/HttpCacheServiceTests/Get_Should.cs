namespace PhotoArtSystem.Tests.UnitTests.Services.HttpCacheServiceTests
{
    using System;
    using Common.Constants;
    using Mocks;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Services.Web;

    [TestFixture]
    public class Get_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_ItemName_IsNull()
        {
            // Arange
            var mockedFunc = new Mock<Func<DummyGuidClass>>();
            var durationInSeconds = (uint)1;
            var service = new HttpCacheService();

            // Act & Assert
            Assert.That(
                () => service.Get(null, mockedFunc.Object, durationInSeconds),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.ItemNameRequiredExceptionMessage));
        }
    }
}
