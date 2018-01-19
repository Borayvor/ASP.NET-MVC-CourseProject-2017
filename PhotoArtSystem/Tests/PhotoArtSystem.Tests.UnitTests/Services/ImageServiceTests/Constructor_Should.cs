namespace PhotoArtSystem.Tests.UnitTests.Services.ImageServiceTests
{
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.CloudStorages.Contracts;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.Factories;
    using PhotoArtSystem.Services.Data;
    using PhotoArtSystem.Services.Web.Contracts;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_ModelDbFactory_IsNull()
        {
            // Arange
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Image>>();
            var mockedImageCloudStorage = new Mock<IImageCloudStorage>();

            // Act & Assert
            Assert.That(
                () => new ImageService(
                    null,
                    mockedMapper.Object,
                    mockedEfDbContext.Object,
                    mockedIEfDbRepository.Object,
                    mockedImageCloudStorage.Object),
                Throws.ArgumentNullException.With.Message.Contains(
                    GlobalConstants.ModelDbFactoryRequiredExceptionMessage));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_Mapper_IsNull()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Image>>();
            var mockedImageCloudStorage = new Mock<IImageCloudStorage>();

            // Act & Assert
            Assert.That(
                () => new ImageService(
                    mockedModelDbFactory.Object,
                    null,
                    mockedEfDbContext.Object,
                    mockedIEfDbRepository.Object,
                    mockedImageCloudStorage.Object),
                Throws.ArgumentNullException.With.Message.Contains(
                    GlobalConstants.AutoMapperServiceRequiredExceptionMessage));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_EfDbContext_IsNull()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Image>>();
            var mockedImageCloudStorage = new Mock<IImageCloudStorage>();

            // Act & Assert
            Assert.That(
                () => new ImageService(
                    mockedModelDbFactory.Object,
                    mockedMapper.Object,
                    null,
                    mockedIEfDbRepository.Object,
                    mockedImageCloudStorage.Object),
                Throws.ArgumentNullException.With.Message.Contains(
                    GlobalConstants.EfDbContextRequiredExceptionMessage));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_EfDbRepositoryOf_Image_IsNull()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Image>>();
            var mockedImageCloudStorage = new Mock<IImageCloudStorage>();

            // Act & Assert
            Assert.That(
                () => new ImageService(
                    mockedModelDbFactory.Object,
                    mockedMapper.Object,
                    mockedEfDbContext.Object,
                    null,
                    mockedImageCloudStorage.Object),
                Throws.ArgumentNullException.With.Message.Contains(
                    GlobalConstants.ImageEfDbRepositoryRequiredExceptionMessage));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_ImageCloudStorage_IsNull()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Image>>();

            // Act & Assert
            Assert.That(
                () => new ImageService(
                    mockedModelDbFactory.Object,
                    mockedMapper.Object,
                    mockedEfDbContext.Object,
                    mockedIEfDbRepository.Object,
                    null),
                Throws.ArgumentNullException.With.Message.Contains(
                    GlobalConstants.CloudStorageRequiredExceptionMessage));
        }

        [Test]
        public void NotThrow_WhenArguments_AreValid()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Image>>();
            var mockedImageCloudStorage = new Mock<IImageCloudStorage>();

            // Act & Assert
            Assert.DoesNotThrow(() => new ImageService(
                    mockedModelDbFactory.Object,
                    mockedMapper.Object,
                    mockedEfDbContext.Object,
                    mockedIEfDbRepository.Object,
                    mockedImageCloudStorage.Object));
        }
    }
}
