namespace PhotoArtSystem.Tests.UnitTests.Data.DbModels
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.PhotocourseModels;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class PhotocourseTests
    {
        [Test]
        public void Setters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            Fixture fixture = new Fixture();
            var expectedName = fixture.Create<string>();
            var expectedDescription = fixture.Create<string>();
            var expectedOtherInfo = fixture.Create<string>();
            var expectedPhotoArtServiceId = fixture.Create<int>();
            var mockedPhotoArtService = new Mock<PhotoArtService>();
            var expectedPhotoArtService = mockedPhotoArtService.Object;

            var photocourse = new Photocourse
            {
                Name = expectedName,
                Description = expectedDescription,
                OtherInfo = expectedOtherInfo,
                PhotoArtServiceId = expectedPhotoArtServiceId,
                PhotoArtService = expectedPhotoArtService
            };

            // Act & Assert
            Assert.AreEqual(expectedName, photocourse.Name);
            Assert.AreEqual(expectedDescription, photocourse.Description);
            Assert.AreEqual(expectedOtherInfo, photocourse.OtherInfo);
            Assert.AreEqual(expectedPhotoArtServiceId, photocourse.PhotoArtServiceId);
            Assert.AreEqual(expectedPhotoArtService, photocourse.PhotoArtService);
            Assert.IsInstanceOf<HashSet<Lesson>>(photocourse.Lessons);
            Assert.IsInstanceOf<HashSet<ImageLink>>(photocourse.Images);
            Assert.IsInstanceOf<HashSet<PhotocourseGroup>>(photocourse.Groups);
        }
    }
}
