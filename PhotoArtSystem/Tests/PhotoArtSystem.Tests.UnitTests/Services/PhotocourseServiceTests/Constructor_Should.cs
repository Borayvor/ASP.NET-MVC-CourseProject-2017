namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseServiceTests
{
    using Common.Constants;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Services.Data;
    using PhotoArtSystem.Services.Web.Contracts;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_Mapper_IsNull()
        {
            // Arange
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

            // Act & Assert
            Assert.That(
                () => new PhotocourseService(null, mockedEfDbContext.Object, mockedIEfDbRepository.Object),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.AutoMapperServiceRequiredExceptionMessage));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_EfDbContext_IsNull()
        {
            // Arange
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

            // Act & Assert
            Assert.That(
                () => new PhotocourseService(mockedMapper.Object, null, mockedIEfDbRepository.Object),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.EfDbContextRequiredExceptionMessage));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_EfDbRepositoryOf_Photocourse_IsNull()
        {
            // Arange
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();

            // Act & Assert
            Assert.That(
                () => new PhotocourseService(mockedMapper.Object, mockedEfDbContext.Object, null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.EfDbRepositoryPhotocourseRequiredExceptionMessage));
        }

        [Test]
        public void NotThrow_WhenArguments_AreValid()
        {
            // Arange
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

            // Act & Assert
            Assert.DoesNotThrow(() => new PhotocourseService(
                mockedMapper.Object,
                mockedEfDbContext.Object,
                mockedIEfDbRepository.Object));
        }
    }
}
