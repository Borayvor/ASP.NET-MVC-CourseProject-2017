namespace PhotoArtSystem.Tests.UnitTests.Services.MainInfoServiceTests
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
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<MainInfo>>();

            var service = new MainInfoService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            service.GetAll();

            // Assert
            mockedIEfDbRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnProperlyResult_When_MainInfoList_IsNotEmpty()
        {
            // Arange
            var entityList = new List<MainInfo>();
            var mockedEntity = new Mock<MainInfoTransitional>();

            var expected = new List<MainInfoTransitional>();
            expected.Add(mockedEntity.Object);

            var mockedMapper = new Mock<IAutoMapperService>();
            mockedMapper
                .Setup(x => x.Map<IEnumerable<MainInfoTransitional>>(It.IsAny<IEnumerable<MainInfo>>()))
                .Returns(expected);

            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<MainInfo>>();
            mockedIEfDbRepository.Setup(x => x.GetAll()).Returns(entityList.AsQueryable());

            var service = new MainInfoService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            var actual = service.GetAll();

            // Assert
            Assert.AreSame(expected[0], actual.ToList()[0]);
        }
    }
}
