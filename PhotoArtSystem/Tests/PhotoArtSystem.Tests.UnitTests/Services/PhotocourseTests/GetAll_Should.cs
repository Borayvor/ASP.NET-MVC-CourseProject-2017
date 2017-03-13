namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models.Contracts;
    using PhotoArtSystem.Services.Photocourse;

    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void CallRepository_GetAll_MethodOnce()
        {
            // Arange
            var mockedEfDbContext = new Mock<IEfDbContext>();
            var mockedIEfDbRepository = new Mock<IEfDbRepository<IPhotocourse>>();

            var service = new PhotocourseService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            service.GetAll();

            // Assert
            mockedIEfDbRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnProperlyResultFromRepository_GetAll_Method()
        {
            // Arange
            var expected = new List<IPhotocourse>();
            var mockedEfDbContext = new Mock<IEfDbContext>();
            var mockedIEfDbRepository = new Mock<IEfDbRepository<IPhotocourse>>();

            // TODO: refactor PhotocourseService.All() to return IEnumerable
            ////mockedIEfDbRepository.Setup(x => x.All()).Returns(expected);

            var service = new PhotocourseService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            var actual = service.GetAll();

            // Assert
            Assert.AreSame(expected, actual);
        }
    }
}
