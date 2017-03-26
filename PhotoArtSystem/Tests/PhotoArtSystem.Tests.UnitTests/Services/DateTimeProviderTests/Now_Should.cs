namespace PhotoArtSystem.Tests.UnitTests.Services.DateTimeProviderTests
{
    using System;
    using NUnit.Framework;
    using PhotoArtSystem.Services.Web;

    [TestFixture]
    public class Now_Should
    {
        [Test]
        public void Return_CurrentDateTime()
        {
            // Arange
            var date = new DateTimeProvider();

            // Act & Assert
            Assert.IsInstanceOf<DateTime>(date.Now);
        }
    }
}
