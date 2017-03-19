namespace PhotoArtSystem.Tests.UnitTests.Data.DbModels
{
    using System;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.PhotocourseModels;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class PhotocourseGroupTests
    {
        [Test]
        public void Setters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            Fixture fixture = new Fixture();
            var expectedDurationHours = fixture.Create<ushort>();
            var expectedStartDate = fixture.Create<DateTime>();
            var expectedEndDate = fixture.Create<DateTime>();
            var expectedTeacher = fixture.Create<string>();
            var expectedPrice = fixture.Create<double>();
            var expectedOtherInfo = fixture.Create<string>();
            var expectedPhotocourseId = fixture.Create<Guid>();
            var mockedPhotocourse = new Mock<Photocourse>();
            var expectedPhotocourse = mockedPhotocourse.Object;
            var expectedImageLinkId = fixture.Create<Guid>();
            var mockedImageLink = new Mock<ImageLink>();
            var expectedImageLink = mockedImageLink.Object;

            var photocourseGroup = new PhotocourseGroup
            {
                DurationHours = expectedDurationHours,
                StartDate = expectedStartDate,
                EndDate = expectedEndDate,
                Teacher = expectedTeacher,
                Price = expectedPrice,
                OtherInfo = expectedOtherInfo,
                PhotocourseId = expectedPhotocourseId,
                Photocourse = expectedPhotocourse,
                ImageLinkId = expectedImageLinkId,
                ImageLink = expectedImageLink
            };

            // Act & Assert
            Assert.AreEqual(expectedDurationHours, photocourseGroup.DurationHours);
            Assert.AreEqual(expectedStartDate, photocourseGroup.StartDate);
            Assert.AreEqual(expectedEndDate, photocourseGroup.EndDate);
            Assert.AreEqual(expectedTeacher, photocourseGroup.Teacher);
            Assert.AreEqual(expectedPrice, photocourseGroup.Price);
            Assert.AreEqual(expectedOtherInfo, photocourseGroup.OtherInfo);
            Assert.AreEqual(expectedPhotocourseId, photocourseGroup.PhotocourseId);
            Assert.AreEqual(expectedPhotocourse, photocourseGroup.Photocourse);
            Assert.AreEqual(expectedImageLinkId, photocourseGroup.ImageLinkId);
            Assert.AreEqual(expectedImageLink, photocourseGroup.ImageLink);
        }
    }
}
