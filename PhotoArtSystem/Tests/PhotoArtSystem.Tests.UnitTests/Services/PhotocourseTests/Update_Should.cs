namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    ////using Common.Constants;
    ////using Moq;
    ////using NUnit.Framework;
    ////using PhotoArtSystem.Data.Common.EfDbContexts;
    ////using PhotoArtSystem.Data.Common.Repositories;
    ////using PhotoArtSystem.Data.Models;
    ////using PhotoArtSystem.Services.Data;

    ////[TestFixture]
    ////public class Update_Should
    ////{
    ////    [Test]
    ////    public void Throw_ArgumentNullException_WithProperMessage_When_Photocourse_IsNull()
    ////    {
    ////        // Arange
    ////        var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
    ////        var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();
    ////        var service = new PhotocourseService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

    ////        // Act & Assert
    ////        Assert.That(
    ////            () => service.Update(null),
    ////                        Throws.ArgumentNullException.With.Message.Contains(
    ////                            GlobalConstants.PhotocourseRequiredExceptionMessage));
    ////    }

    ////    [Test]
    ////    public void CallOnce_EfDbContextSave_When_Photocourse_IsNotNull()
    ////    {
    ////        // Arange
    ////        var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
    ////        var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();
    ////        var service = new PhotocourseService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

    ////        // Act
    ////        service.Update(new Photocourse());

    ////        // Assert
    ////        mockedEfDbContext.Verify(x => x.Save(), Times.Once);
    ////    }
    ////}
}
