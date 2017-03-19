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
            var expectedFileName = fixture.Create<string>();
            var expectedContentType = fixture.Create<string>();
            var expectedContent = fixture.Create<byte[]>();

            var originalImage = new OriginalImage
            {
                FileName = expectedFileName,
                ContentType = expectedContentType,
                Content = expectedContent
            };

            // Act & Assert
            Assert.AreEqual(expectedFileName, originalImage.FileName);
            Assert.AreEqual(expectedContentType, originalImage.ContentType);
            Assert.AreEqual(expectedContent, originalImage.Content);
        }
    }
}
