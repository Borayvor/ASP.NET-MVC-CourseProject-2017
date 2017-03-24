namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    // TODO: implement GetAll_Should

    ////using System.Collections.Generic;
    ////using System.Linq;
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
    ////        var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
    ////        var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

    ////        var service = new PhotocourseService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

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
    ////        var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
    ////        var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();
    ////        mockedIEfDbRepository.Setup(x => x.GetAll()).Returns(expected.AsQueryable());

    ////        var service = new PhotocourseService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

    ////        // Act
    ////        var actual = service.GetAll();

    ////        // Assert
    ////        Assert.AreSame(expected[0], actual.ToList()[0]);
    ////    }
    ////}
}
