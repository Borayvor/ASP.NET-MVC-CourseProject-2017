namespace PhotoArtSystem.Tests.UnitTests.Services.ImageServiceTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Moq;

    using NUnit.Framework;

    using PhotoArtSystem.CloudStorages.Contracts;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.EnumTypes;
    using PhotoArtSystem.Data.Models.Factories;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using PhotoArtSystem.Services.Data;
    using PhotoArtSystem.Services.Web.Contracts;

    [TestFixture]
    public class Create_Many_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_ImageTransitional_IsNull()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Image>>();
            var mockedImageCloudStorage = new Mock<IImageCloudStorage>();
            var imageFormatType = ImageFormatType.Ordinary;

            var service = new ImageService(
                mockedModelDbFactory.Object,
                    mockedMapper.Object,
                    mockedEfDbContext.Object,
                    mockedIEfDbRepository.Object,
                    mockedImageCloudStorage.Object);

            // Act & Assert
            Assert.That(
                () => service.Create((IEnumerable<ImageTransitional>)null, imageFormatType),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.ImageTransitionalCollectionRequiredExceptionMessage));
        }

        [Test]
        public async Task CallOnce_EfDbContextSave_When_ImageTransitional_IsNotNull()
        {
            // Arange
            var mockedModelDbFactory = new Mock<IModelDbFactory>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Image>>();
            var mockedImageCloudStorage = new Mock<IImageCloudStorage>();
            var imageFormatType = ImageFormatType.Ordinary;

            var service = new ImageService(
                mockedModelDbFactory.Object,
                    mockedMapper.Object,
                    mockedEfDbContext.Object,
                    mockedIEfDbRepository.Object,
                    mockedImageCloudStorage.Object);

            // Act
            await service.Create(new ImageTransitional(), imageFormatType);

            // Assert
            mockedEfDbContext.Verify(x => x.SaveAsync(), Times.Once);
        }
    }
}
