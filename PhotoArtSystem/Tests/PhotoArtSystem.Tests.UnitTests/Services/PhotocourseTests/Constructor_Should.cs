namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    // TODO: implement Constructor_Should

    ////using Common.Constants;
    ////using Moq;
    ////using NUnit.Framework;
    ////using PhotoArtSystem.Data.Common.EfDbContexts;
    ////using PhotoArtSystem.Data.Common.Repositories;
    ////using PhotoArtSystem.Data.Models;
    ////using PhotoArtSystem.Services.Data;

    ////[TestFixture]
    ////public class Constructor_Should
    ////{
    ////    [Test]
    ////    public void Throw_ArgumentNullException_WithProperMessage_When_EfDbContext_IsNull()
    ////    {
    ////        // Arange
    ////        var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

    ////        // Act & Assert
    ////        Assert.That(
    ////            () => new PhotocourseService(null, mockedIEfDbRepository.Object),
    ////                        Throws.ArgumentNullException.With.Message.Contains(
    ////                            GlobalConstants.EfDbContextRequiredExceptionMessage));
    ////    }

    ////    [Test]
    ////    public void Throw_ArgumentNullException_WithProperMessage_When_EfDbRepositoryOfPhotocourse_IsNull()
    ////    {
    ////        // Arange
    ////        var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();

    ////        // Act & Assert
    ////        Assert.That(
    ////            () => new PhotocourseService(mockedEfDbContext.Object, null),
    ////                        Throws.ArgumentNullException.With.Message.Contains(
    ////                            GlobalConstants.EfDbRepositoryPhotocourseRequiredExceptionMessage));
    ////    }

    ////    [Test]
    ////    public void NotThrow_WhenArguments_AreValid()
    ////    {
    ////        // Arange
    ////        var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
    ////        var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

    ////        // Act & Assert
    ////        Assert.DoesNotThrow(() => new PhotocourseService(mockedEfDbContext.Object, mockedIEfDbRepository.Object));
    ////    }
    ////}
}
