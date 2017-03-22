namespace PhotoArtSystem.Tests.UnitTests.Data.DbModels
{
    using NUnit.Framework;
    using PhotoArtSystem.Data.Models;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class OriginalImageTests
    {
        [Test]
        public void Setters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            Fixture fixture = new Fixture();

            var expectedContent = fixture.Create<byte[]>();

            var originalImage = new OriginalImage
            {
                Content = expectedContent
            };

            // Act & Assert
            Assert.AreEqual(expectedContent, originalImage.Content);
        }
    }
}
