namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    using System;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models.PhotocourseModels;
    using PhotoArtSystem.Services.Photocourses;
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
            var mockedModel = new Photocourse();
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
