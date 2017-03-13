﻿namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    using Common.Constants;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Services.Photocourse;

    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_Photocourse_IsNull()
        {
            // Arange
            var mockedEfDbContext = new Mock<IEfDbContext>();
            var mockedIEfDbRepository = new Mock<IEfDbRepository<Photocourse>>();
            var mockedPhotocourseService = new PhotocourseService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act & Assert
            Assert.That(
                () => mockedPhotocourseService.Create(null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.PhotocourseRequiredExceptionMessage));
        }
    }
}
