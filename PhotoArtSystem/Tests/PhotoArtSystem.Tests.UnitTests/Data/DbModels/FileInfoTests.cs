namespace PhotoArtSystem.Tests.UnitTests.Data.DbModels
{
    using Common.EnumTypes;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Models;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class FileInfoTests
    {
        [Test]
        public void Setters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            Fixture fixture = new Fixture();
            var expectedFileName = fixture.Create<string>();
            var expectedFileExtension = fixture.Create<string>();
            var expectedUrlPath = fixture.Create<string>();
            var expectedFileSize = fixture.Create<FileSizeType>();
            ////var expectedPhotocourseId = fixture.Create<Guid>();
            ////var mockedPhotocourse = new Mock<Photocourse>();
            ////var expectedPhotocourse = mockedPhotocourse.Object;
            ////var expectedPhotocourseGroupId = fixture.Create<Guid>();
            ////var mockedPhotocourseGroup = new Mock<Student>();
            ////var expectedPhotocourseGroup = mockedPhotocourseGroup.Object;

            var fileInfo = new FileInfo
            {
                FileName = expectedFileName,
                FileExtension = expectedFileExtension,
                UrlPath = expectedUrlPath,
                FileSize = expectedFileSize,
                ////PhotocourseId = expectedPhotocourseId,
                ////Photocourse = expectedPhotocourse,
                ////PhotocourseGroupId = expectedPhotocourseGroupId,
                ////PhotocourseGroup = expectedPhotocourseGroup,
            };

            // Act & Assert
            Assert.AreEqual(expectedFileName, fileInfo.FileName);
            Assert.AreEqual(expectedFileExtension, fileInfo.FileExtension);
            Assert.AreEqual(expectedUrlPath, fileInfo.UrlPath);
            Assert.AreEqual(expectedFileSize, fileInfo.FileSize);
            ////Assert.AreEqual(expectedPhotocourseId, fileInfo.PhotocourseId);
            ////Assert.AreEqual(expectedPhotocourse, fileInfo.Photocourse);
            ////Assert.AreEqual(expectedPhotocourseGroupId, fileInfo.PhotocourseGroupId);
            ////Assert.AreEqual(expectedPhotocourseGroup, fileInfo.PhotocourseGroup);
        }
    }
}
