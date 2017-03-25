namespace PhotoArtSystem.Tests.UnitTests.Data.DbModels
{
    using System;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.EnumTypes;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class ImageTests
    {
        [Test]
        public void Setters_ShouldSetExpectedProperties()
        {
            // Arrange
            Fixture fixture = new Fixture();
            var expectedFileName = fixture.Create<string>();
            var expectedFileExtension = fixture.Create<string>();
            var expectedUrlPath = fixture.Create<string>();
            var expectedFileSize = fixture.Create<FileSizeType>();
            var expectedPhotocourseId = fixture.Create<Guid>();

            var image = new Image
            {
                FileName = expectedFileName,
                FileExtension = expectedFileExtension,
                UrlPath = expectedUrlPath,
                FileSize = expectedFileSize,
                PhotocourseId = expectedPhotocourseId,
                Photocourse = null
            };

            // Act & Assert
            Assert.AreEqual(expectedFileName, image.FileName);
            Assert.AreEqual(expectedFileExtension, image.FileExtension);
            Assert.AreEqual(expectedUrlPath, image.UrlPath);
            Assert.AreEqual(expectedFileSize, image.FileSize);
            Assert.AreEqual(expectedPhotocourseId, image.PhotocourseId);
            Assert.AreEqual(null, image.Photocourse);
        }
    }
}
