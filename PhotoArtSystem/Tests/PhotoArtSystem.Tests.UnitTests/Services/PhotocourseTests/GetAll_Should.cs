namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    ////using System.Collections.Generic;
    ////using System.Linq;
    ////using AutoMapper;
    ////using Moq;
    ////using NUnit.Framework;
    ////using PhotoArtSystem.Data.Common.EfDbContexts;
    ////using PhotoArtSystem.Data.Common.Repositories;
    ////using PhotoArtSystem.Data.Models;
    ////using PhotoArtSystem.Services.Data;

    ////[TestFixture]
    ////public class GetAll_Should
    ////{
    ////    [Test]
    ////    public void CallEfDbRepository_GetAll_MethodOnce()
    ////    {
    ////        // Arange

    ////        // TODO: implement
    ////        var mockedMapper = new Mock<IMapper>();
    ////        var mockedQueriable = new Mock<IQueryable<Photocourse>>();
    ////        var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
    ////        var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

    ////        mockedIEfDbRepository.Setup(x => x.GetAll()).Returns(mockedQueriable.Object);

    ////        var service = new PhotocourseService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

    ////        // Act
    ////        service.GetAll();

    ////        // Assert
    ////        mockedIEfDbRepository.Verify(x => x.GetAll(), Times.Once);
    ////    }

    ////    [Test]
    ////    public void ReturnProperlyResultFromEfDbRepository_GetAll_Method()
    ////    {
    ////        // Arange
    ////        var expected = new List<Photocourse>()
    ////        {
    ////            new Photocourse()
    ////        };

    ////        var mockedMapper = new Mock<IMapper>();
    ////        var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
    ////        var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();
    ////        mockedIEfDbRepository.Setup(x => x.GetAll()).Returns(expected.AsQueryable());

    ////        var service = new PhotocourseService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

    ////        // Act
    ////        var actual = service.GetAll();

    ////        // Assert
    ////        Assert.AreSame(expected[0], actual.ToList()[0]);
    ////    }
    ////}
}
