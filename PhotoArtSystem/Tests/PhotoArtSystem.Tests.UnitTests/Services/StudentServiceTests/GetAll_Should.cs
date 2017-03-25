namespace PhotoArtSystem.Tests.UnitTests.Services.StudentServiceTests
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
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Student>>();

            var service = new StudentService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            service.GetAll();

            // Assert
            mockedIEfDbRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnProperlyResult_When_Student_IsNotEmpty()
        {
            // Arange
            var entityList = new List<Student>();
            var mockedEntity = new Mock<StudentTransitional>();

            var expected = new List<StudentTransitional>();
            expected.Add(mockedEntity.Object);

            var mockedMapper = new Mock<IAutoMapperService>();
            mockedMapper
                .Setup(x => x.Map<IEnumerable<StudentTransitional>>(It.IsAny<IEnumerable<Student>>()))
                .Returns(expected);

            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Student>>();
            mockedIEfDbRepository.Setup(x => x.GetAll()).Returns(entityList.AsQueryable());

            var service = new StudentService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            var actual = service.GetAll();

            // Assert
            Assert.AreSame(expected[0], actual.ToList()[0]);
        }
    }
}
