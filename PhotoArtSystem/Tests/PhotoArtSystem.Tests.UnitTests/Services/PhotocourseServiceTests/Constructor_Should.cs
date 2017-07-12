namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseServiceTests
{
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.Factories;
    using PhotoArtSystem.Services.Data;
    using PhotoArtSystem.Services.Web.Contracts;
    using Web.Infrastructure.Sanitizer;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_ModelDbFactory_IsNull()
        {
            // Arange
            var mockedSanitizer = new Mock<ISanitizer>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

            // Act & Assert
            Assert.That(
                () => new PhotocourseService(
                    null,
                    mockedSanitizer.Object,
                    mockedMapper.Object,
                    mockedEfDbContext.Object,
                    mockedIEfDbRepository.Object),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.ModelDbFactoryRequiredExceptionMessage));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_Sanitizer_IsNull()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

            // Act & Assert
            Assert.That(
                () => new PhotocourseService(
                    mockedModelDbFactory.Object,
                    null,
                    mockedMapper.Object,
                    mockedEfDbContext.Object,
                    mockedIEfDbRepository.Object),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.SanitizerRequiredExceptionMessage));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_Mapper_IsNull()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedSanitizer = new Mock<ISanitizer>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

            // Act & Assert
            Assert.That(
                () => new PhotocourseService(
                    mockedModelDbFactory.Object,
                    mockedSanitizer.Object,
                    null,
                    mockedEfDbContext.Object,
                    mockedIEfDbRepository.Object),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.AutoMapperServiceRequiredExceptionMessage));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_EfDbContext_IsNull()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedSanitizer = new Mock<ISanitizer>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

            // Act & Assert
            Assert.That(
                () => new PhotocourseService(
                    mockedModelDbFactory.Object,
                    mockedSanitizer.Object,
                    mockedMapper.Object,
                    null,
                    mockedIEfDbRepository.Object),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.EfDbContextRequiredExceptionMessage));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_EfDbRepositoryOf_Photocourse_IsNull()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedSanitizer = new Mock<ISanitizer>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();

            // Act & Assert
            Assert.That(
                () => new PhotocourseService(
                    mockedModelDbFactory.Object,
                    mockedSanitizer.Object,
                    mockedMapper.Object,
                    mockedEfDbContext.Object,
                    null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.PhotocourseEfDbRepositoryRequiredExceptionMessage));
        }

        [Test]
        public void NotThrow_WhenArguments_AreValid()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedSanitizer = new Mock<ISanitizer>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

            // Act & Assert
            Assert.DoesNotThrow(() => new PhotocourseService(
                mockedModelDbFactory.Object,
                mockedSanitizer.Object,
                mockedMapper.Object,
                mockedEfDbContext.Object,
                mockedIEfDbRepository.Object));
        }
    }
}
