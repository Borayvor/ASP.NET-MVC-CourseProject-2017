namespace PhotoArtSystem.Tests.UnitTests.Services.PhotoArtServiceServiceTests
{
    using Common.Constants;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Services.PhotoArtServices;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_EfDbContext_IsNull()
        {
            // Arange
            var mockedIEfDbRepository = new Mock<IEfDbRepository<PhotoArtService>>();

            // Act & Assert
            Assert.That(
                () => new PhotoArtServiceService(null, mockedIEfDbRepository.Object),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.EfDbContextRequiredExceptionMessage));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_EfDbRepositoryOfPhotocourse_IsNull()
        {
            // Arange
            var mockedEfDbContext = new Mock<IEfDbContext>();

            // Act & Assert
            Assert.That(
                () => new PhotoArtServiceService(mockedEfDbContext.Object, null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.EfDbRepositoryPhotoArtServiceRequiredExceptionMessage));
        }

        [Test]
        public void NotThrow_WhenArguments_AreValid()
        {
            // Arange
            var mockedEfDbContext = new Mock<IEfDbContext>();
            var mockedIEfDbRepository = new Mock<IEfDbRepository<PhotoArtService>>();

            // Act & Assert
            Assert.DoesNotThrow(() => new PhotoArtServiceService(mockedEfDbContext.Object, mockedIEfDbRepository.Object));
        }
    }
}
