namespace PhotoArtSystem.Tests.UnitTests.Data.DbModels
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Models;
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

            // TODO: change tests
            var photocourse = new Photocourse
            {
                Name = expectedName,
                Description = expectedDescription,
                OtherInfo = expectedOtherInfo
            };

            // Act & Assert
            Assert.AreEqual(expectedName, photocourse.Name);
            Assert.AreEqual(expectedDescription, photocourse.Description);
            Assert.AreEqual(expectedOtherInfo, photocourse.OtherInfo);
            Assert.IsInstanceOf<HashSet<Image>>(photocourse.Images);
            Assert.IsInstanceOf<HashSet<Student>>(photocourse.Groups);
        }
    }
}
