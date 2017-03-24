namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    ////using System;
    ////using AutoMapper;
    ////using Moq;
    ////using NUnit.Framework;
    ////using PhotoArtSystem.Data.Common.EfDbContexts;
    ////using PhotoArtSystem.Data.Common.Repositories;
    ////using PhotoArtSystem.Data.Models;
    ////using PhotoArtSystem.Services.Data;
    ////using Ploeh.AutoFixture;

    ////[TestFixture]
    ////public class GetById_Should
    ////{
    ////    [Test]
    ////    public void CallEfDbRepository_GetById_MethodOnce()
    ////    {
    ////        // Arange
    ////        Fixture fixture = new Fixture();
    ////        var id = fixture.Create<Guid>();
    ////        var mockedModel = new Mock<Photocourse>();
    ////        var mockedMapper = new Mock<IMapper>();
    ////        var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
    ////        var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

    ////        mockedIEfDbRepository.Setup(x => x.GetById(id)).Returns(mockedModel.Object);

    ////        var service = new PhotocourseService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

    ////        // Act
    ////        var result = service.GetById(id);

    ////        // Assert
    ////        mockedIEfDbRepository.Verify(x => x.GetById(id), Times.Once);
    ////    }

    ////    [Test]
    ////    public void ReturnProperlyResultFromEfDbRepository()
    ////    {
    ////        // Arange
    ////        Fixture fixture = new Fixture();
    ////        var id = fixture.Create<Guid>();
    ////        var mockedModel = new Mock<Photocourse>();
    ////        var mockedMapper = new Mock<IMapper>();
    ////        var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
    ////        var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();
    ////        mockedIEfDbRepository.Setup(x => x.GetById(id)).Returns(mockedModel.Object);

    ////        var service = new PhotocourseService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

    ////        // Act
    ////        var result = service.GetById(id);

    ////        // Assert
    ////        Assert.AreSame(mockedModel.Object, result);
    ////    }
    ////}
}
