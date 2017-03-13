namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Services.Photocourse;

    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnProperlyResultFromRepository()
        {
            // Arange
            ////Fixture fixture = new Fixture();
            ////var id = fixture.Create<Guid>();
            var mockedModel = new Photocourse();
            var id = mockedModel.Id;
            ////mockedModel.Setup(x => x.Id).Returns(id);

            var mockedEfDbContext = new Mock<IEfDbContext>();
            var mockedIEfDbRepository = new Mock<IEfDbRepository<Photocourse>>();
            mockedIEfDbRepository.Setup(x => x.GetById(id)).Returns(mockedModel);

            var service = new PhotocourseService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            var result = service.GetById(id);

            // Assert
            Assert.AreSame(mockedModel, result);
        }
    }
}
