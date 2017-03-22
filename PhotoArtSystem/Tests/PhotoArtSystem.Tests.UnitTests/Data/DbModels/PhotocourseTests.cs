namespace PhotoArtSystem.Tests.UnitTests.Data.DbModels
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Models;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class PhotocourseTests
    {
        [Test]
        public void Setters_ShouldSetExpectedProperties()
        {
            // Arrange
            Fixture fixture = new Fixture();
            var expectedName = fixture.Create<string>();
            var expectedDescriptionShort = fixture.Create<string>();
            var expectedDescription = fixture.Create<string>();
            var expectedOtherInfo = fixture.Create<string>();
            var expectedDurationHours = fixture.Create<ushort>();
            var expectedStartDate = fixture.Create<DateTime>();
            var expectedEndDate = fixture.Create<DateTime>();
            var expectedTeacher = fixture.Create<string>();
            var expectedMaxStudents = fixture.Create<int>();
            var expectedPhotoArtServiceId = fixture.Create<int>();

            var photocourse = new Photocourse
            {
                Name = expectedName,
                DescriptionShort = expectedDescriptionShort,
                Description = expectedDescription,
                OtherInfo = expectedOtherInfo,
                DurationHours = expectedDurationHours,
                StartDate = expectedStartDate,
                EndDate = expectedEndDate,
                Teacher = expectedTeacher,
                MaxStudents = expectedMaxStudents
            };

            // Act & Assert
            Assert.AreEqual(expectedName, photocourse.Name);
            Assert.AreEqual(expectedDescriptionShort, photocourse.DescriptionShort);
            Assert.AreEqual(expectedDescription, photocourse.Description);
            Assert.AreEqual(expectedOtherInfo, photocourse.OtherInfo);
            Assert.AreEqual(expectedDurationHours, photocourse.DurationHours);
            Assert.AreEqual(expectedStartDate, photocourse.StartDate);
            Assert.AreEqual(expectedEndDate, photocourse.EndDate);
            Assert.AreEqual(expectedTeacher, photocourse.Teacher);
            Assert.AreEqual(expectedMaxStudents, photocourse.MaxStudents);
            Assert.IsInstanceOf<HashSet<Image>>(photocourse.Images);
            Assert.IsInstanceOf<HashSet<Student>>(photocourse.Groups);
        }
    }
}
