namespace PhotoArtSystem.Tests.UnitTests.Services.MainInfoServiceTests
{
    using System;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using PhotoArtSystem.Services.Data;
    using PhotoArtSystem.Services.Web.Contracts;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void CallEfDbRepository_GetById_MethodOnce()
        {
            // Arange
            Fixture fixture = new Fixture();
            var id = fixture.Create<Guid>();
            var mockedEntity = new Mock<MainInfo>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<MainInfo>>();

            mockedIEfDbRepository.Setup(x => x.GetById(id)).Returns(mockedEntity.Object);

            var service = new MainInfoService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            var result = service.GetById(id);

            // Assert
            mockedIEfDbRepository.Verify(x => x.GetById(id), Times.Once);
        }

        [Test]
        public void ReturnProperlyResult_From_EfDbRepository()
        {
            // Arange
            Fixture fixture = new Fixture();
            var id = fixture.Create<Guid>();
            var mockedEntity = new Mock<MainInfo>();
            var expectedMockedEntity = new Mock<MainInfoTransitional>();
            var mockedMapper = new Mock<IAutoMapperService>();
            mockedMapper
               .Setup(x => x.Map<MainInfoTransitional>(It.IsAny<MainInfo>()))
               .Returns(expectedMockedEntity.Object);

            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<MainInfo>>();
            mockedIEfDbRepository.Setup(x => x.GetById(id)).Returns(mockedEntity.Object);

            var service = new MainInfoService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            var actual = service.GetById(id);

            // Assert
            Assert.AreSame(expectedMockedEntity.Object, actual);
        }
    }
}
