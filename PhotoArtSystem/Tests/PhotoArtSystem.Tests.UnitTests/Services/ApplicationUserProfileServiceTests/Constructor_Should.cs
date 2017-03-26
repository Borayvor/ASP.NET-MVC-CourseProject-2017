namespace PhotoArtSystem.Tests.UnitTests.Services.ApplicationUserProfileServiceTests
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
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<ApplicationUser>>();

            // Act & Assert
            Assert.That(
                () => new ApplicationUserProfileService(null, mockedIEfDbRepository.Object),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.AutoMapperServiceRequiredExceptionMessage));
        }

        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_EfDbRepositoryOf_ApplicationUser_IsNull()
        {
            // Arange
            var mockedMapper = new Mock<IAutoMapperService>();

            // Act & Assert
            Assert.That(
                () => new ApplicationUserProfileService(mockedMapper.Object, null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.EfDbRepositoryApplicationUserRequiredExceptionMessage));
        }

        [Test]
        public void NotThrow_WhenArguments_AreValid()
        {
            // Arange
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<ApplicationUser>>();

            // Act & Assert
            Assert.DoesNotThrow(() => new ApplicationUserProfileService(
                mockedMapper.Object,
                mockedIEfDbRepository.Object));
        }
    }
}
