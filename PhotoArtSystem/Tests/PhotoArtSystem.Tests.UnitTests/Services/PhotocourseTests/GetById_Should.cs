namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    using System;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models.Contracts;
    using PhotoArtSystem.Services.Photocourse;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnProperlyResultFromRepository()
        {
            // Arange
            Fixture fixture = new Fixture();
            var id = fixture.Create<Guid>();
            var mockedModel = new Mock<IPhotocourse>();
            mockedModel.Setup(x => x.Id).Returns(id);

            var mockedEfDbContext = new Mock<IEfDbContext>();
            var mockedIEfDbRepository = new Mock<IEfDbRepository<IPhotocourse>>();
            mockedIEfDbRepository.Setup(x => x.GetById(id)).Returns(mockedModel.Object);

            var service = new PhotocourseService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            var result = service.GetById(id);

            // Assert
            Assert.AreSame(mockedModel.Object, result);
        }
    }
}
