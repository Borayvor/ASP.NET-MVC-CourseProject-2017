﻿namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseServiceTests
{
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.Factories;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using PhotoArtSystem.Services.Data;
    using PhotoArtSystem.Services.Web.Contracts;
    using Ploeh.AutoFixture;
    using Web.Infrastructure.Sanitizer;

    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_Photocourse_IsNull()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedSanitizer = new Mock<ISanitizer>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();
            var service = new PhotocourseService(
                mockedModelDbFactory.Object,
                mockedSanitizer.Object,
                mockedMapper.Object,
                mockedEfDbContext.Object,
                mockedIEfDbRepository.Object);

            // Act & Assert
            Assert.That(
                () => service.Create(null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.PhotocourseTransitionalRequiredExceptionMessage));
        }

        [Test]
        public void CallOnce_EfDbContextSave_When_Photocourse_IsNotNull()
        {
            // Arange
            Fixture fixture = new Fixture();
            var sanitaizerResult = fixture.Create<string>();
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedSanitizer = new Mock<ISanitizer>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();
            var service = new PhotocourseService(
                mockedModelDbFactory.Object,
                mockedSanitizer.Object,
                mockedMapper.Object,
                mockedEfDbContext.Object,
                mockedIEfDbRepository.Object);

            mockedSanitizer.Setup(x => x.Sanitize(It.IsAny<string>())).Returns(sanitaizerResult);

            // Act
            service.Create(new PhotocourseTransitional());

            // Assert
            mockedEfDbContext.Verify(x => x.Save(), Times.Once);
        }
    }
}
