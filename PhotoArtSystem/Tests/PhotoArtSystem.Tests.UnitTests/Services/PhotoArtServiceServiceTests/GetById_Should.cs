namespace PhotoArtSystem.Tests.UnitTests.Services.PhotoArtServiceServiceTests
{
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Services.PhotoArtServices;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void CallEfDbRepository_GetById_MethodOnce()
        {
            // Arange
            Fixture fixture = new Fixture();
            var id = fixture.Create<int>();
            var mockedEfDbContext = new Mock<IEfDbContext>();
            var mockedIEfDbRepository = new Mock<IEfDbRepository<PhotoArtService>>();

            var service = new PhotoArtServiceService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            var result = service.GetById(id);

            // Assert
            mockedIEfDbRepository.Verify(x => x.GetById(id), Times.Once);
        }

        [Test]
        public void ReturnProperlyResultFromEfDbRepository()
        {
            // Arange
            Fixture fixture = new Fixture();
            var id = fixture.Create<int>();
            var mockedModel = new PhotoArtService();
            var mockedEfDbContext = new Mock<IEfDbContext>();
            var mockedIEfDbRepository = new Mock<IEfDbRepository<PhotoArtService>>();
            mockedIEfDbRepository.Setup(x => x.GetById(id)).Returns(mockedModel);

            var service = new PhotoArtServiceService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            var result = service.GetById(id);

            // Assert
            Assert.AreSame(mockedModel, result);
        }
    }
}
