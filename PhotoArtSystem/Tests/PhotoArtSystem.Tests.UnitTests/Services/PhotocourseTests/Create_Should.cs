﻿namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    // TODO: implement Create_Should

    ////using Common.Constants;
    ////using Moq;
    ////using NUnit.Framework;
    ////using PhotoArtSystem.Data.Common.EfDbContexts;
    ////using PhotoArtSystem.Data.Common.Repositories;
    ////using PhotoArtSystem.Data.Models;
    ////using PhotoArtSystem.Services.Data;

    ////[TestFixture]
    ////public class Create_Should
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
    ////            () => service.Create(null),
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
    ////        service.Create(new Photocourse());

    ////        // Assert
    ////        mockedEfDbContext.Verify(x => x.Save(), Times.Once);
    ////    }
    ////}
}
