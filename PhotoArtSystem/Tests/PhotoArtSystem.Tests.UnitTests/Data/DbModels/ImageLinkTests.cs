namespace PhotoArtSystem.Tests.UnitTests.Data.DbModels
{
    using System;
    using Common.EnumTypes;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.PhotocourseModels;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class ImageLinkTests
    {
        [Test]
        public void Setters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            Fixture fixture = new Fixture();
            var expectedFileName = fixture.Create<string>();
            var expectedContent = fixture.Create<string>();
            var expectedFileSize = fixture.Create<FileSizeType>();
            var expectedPhotocourseId = fixture.Create<Guid>();
            var mockedPhotocourse = new Mock<Photocourse>();
            var expectedPhotocourse = mockedPhotocourse.Object;
            var expectedPhotocourseGroupId = fixture.Create<Guid>();
            var mockedPhotocourseGroup = new Mock<PhotocourseGroup>();
            var expectedPhotocourseGroup = mockedPhotocourseGroup.Object;

            var imageLink = new ImageLink
            {
                FileName = expectedFileName,
                Content = expectedContent,
                FileSize = expectedFileSize,
                PhotocourseId = expectedPhotocourseId,
                Photocourse = expectedPhotocourse,
                PhotocourseGroupId = expectedPhotocourseGroupId,
                PhotocourseGroup = expectedPhotocourseGroup,
            };

            // Act & Assert
            Assert.AreEqual(expectedFileName, imageLink.FileName);
            Assert.AreEqual(expectedContent, imageLink.Content);
            Assert.AreEqual(expectedFileSize, imageLink.FileSize);
            Assert.AreEqual(expectedPhotocourseId, imageLink.PhotocourseId);
            Assert.AreEqual(expectedPhotocourse, imageLink.Photocourse);
            Assert.AreEqual(expectedPhotocourseGroupId, imageLink.PhotocourseGroupId);
            Assert.AreEqual(expectedPhotocourseGroup, imageLink.PhotocourseGroup);
        }
    }
}
