namespace PhotoArtSystem.Tests.UnitTests.Data.DbModels
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.PhotocourseModels;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class PhotoArtServiceTests
    {
        [Test]
        public void Setters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            Fixture fixture = new Fixture();
            var expectedName = fixture.Create<string>();
            var expectedDescription = fixture.Create<string>();

            var photoArtService = new PhotoArtService
            {
                Name = expectedName,
                Description = expectedDescription
            };

            // Act & Assert
            Assert.AreEqual(expectedName, photoArtService.Name);
            Assert.AreEqual(expectedDescription, photoArtService.Description);
            Assert.IsInstanceOf<HashSet<Photocourse>>(photoArtService.Photocourses);
        }
    }
}
