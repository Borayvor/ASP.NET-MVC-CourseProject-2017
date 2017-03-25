﻿namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using PhotoArtSystem.Services.Data;
    using PhotoArtSystem.Services.Web.Contracts;

    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void CallEfDbRepository_GetAll_MethodOnce()
        {
            // Arange
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();

            var service = new PhotocourseService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            service.GetAll();

            // Assert
            mockedIEfDbRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnProperlyResultWhenPhotocourceListIsNotEmpty()
        {
            // Arange
            var photocourceList = new List<Photocourse>();
            var mockedPhotocourseTransitional = new Mock<PhotocourseTransitional>();

            var expected = new List<PhotocourseTransitional>();
            expected.Add(mockedPhotocourseTransitional.Object);

            var mockedMapper = new Mock<IAutoMapperService>();
            mockedMapper
                .Setup(x => x.Map<IEnumerable<PhotocourseTransitional>>(It.IsAny<IEnumerable<Photocourse>>()))
                .Returns(expected);

            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Photocourse>>();
            mockedIEfDbRepository.Setup(x => x.GetAll()).Returns(photocourceList.AsQueryable());

            var service = new PhotocourseService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            var actual = service.GetAll();

            // Assert
            Assert.AreSame(expected[0], actual.ToList()[0]);
        }
    }
}
