namespace PhotoArtSystem.Tests.UnitTests.Data.DbModels
{
    using System;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Models.PhotocourseModels;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class LessonTests
    {
        [Test]
        public void Setters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            Fixture fixture = new Fixture();
            var expectedName = fixture.Create<string>();
            var expectedPhotocourseId = fixture.Create<Guid>();
            var mockedPhotocourse = new Mock<Photocourse>();
            var expectedPhotocourse = mockedPhotocourse.Object;

            var lesson = new Lesson
            {
                Name = expectedName,
                Photocourse = expectedPhotocourse,
                PhotocourseId = expectedPhotocourseId
            };

            // Act & Assert
            Assert.AreEqual(expectedName, lesson.Name);
            Assert.AreEqual(expectedPhotocourse, lesson.Photocourse);
            Assert.AreEqual(expectedPhotocourseId, lesson.PhotocourseId);
        }
    }
}
