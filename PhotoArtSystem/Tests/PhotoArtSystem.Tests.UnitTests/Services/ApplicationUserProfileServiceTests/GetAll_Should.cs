namespace PhotoArtSystem.Tests.UnitTests.Services.ApplicationUserProfileServiceTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
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
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<ApplicationUser>>();

            var service = new ApplicationUserProfileService(mockedMapper.Object, mockedIEfDbRepository.Object);

            // Act
            service.GetAll();

            // Assert
            mockedIEfDbRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnProperlyResult_When_ApplicationUserList_IsNotEmpty()
        {
            // Arange
            var entityList = new List<ApplicationUser>();
            var mockedEntity = new Mock<ApplicationUserTransitional>();

            var expected = new List<ApplicationUserTransitional>();
            expected.Add(mockedEntity.Object);

            var mockedMapper = new Mock<IAutoMapperService>();
            mockedMapper
                .Setup(x => x.Map<IEnumerable<ApplicationUserTransitional>>(It.IsAny<IEnumerable<ApplicationUser>>()))
                .Returns(expected);

            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<ApplicationUser>>();
            mockedIEfDbRepository.Setup(x => x.GetAll()).Returns(entityList.AsQueryable());

            var service = new ApplicationUserProfileService(mockedMapper.Object, mockedIEfDbRepository.Object);

            // Act
            var actual = service.GetAll();

            // Assert
            Assert.AreSame(expected[0], actual.ToList()[0]);
        }
    }
}
