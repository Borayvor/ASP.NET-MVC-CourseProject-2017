namespace PhotoArtSystem.Tests.UnitTests.Services.ApplicationUserProfileServiceTests
{
    using Moq;
    using NUnit.Framework;
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
            var id = fixture.Create<string>();
            var mockedEntity = new Mock<ApplicationUser>();
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<ApplicationUser>>();

            mockedIEfDbRepository.Setup(x => x.GetById(id)).Returns(mockedEntity.Object);

            var service = new ApplicationUserProfileService(mockedMapper.Object, mockedIEfDbRepository.Object);

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
            var id = fixture.Create<string>();
            var mockedEntity = new Mock<ApplicationUser>();
            var expectedMockedEntity = new Mock<ApplicationUserTransitional>();
            var mockedMapper = new Mock<IAutoMapperService>();
            mockedMapper
               .Setup(x => x.Map<ApplicationUserTransitional>(It.IsAny<ApplicationUser>()))
               .Returns(expectedMockedEntity.Object);

            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<ApplicationUser>>();
            mockedIEfDbRepository.Setup(x => x.GetById(id)).Returns(mockedEntity.Object);

            var service = new ApplicationUserProfileService(mockedMapper.Object, mockedIEfDbRepository.Object);

            // Act
            var actual = service.GetById(id);

            // Assert
            Assert.AreSame(expectedMockedEntity.Object, actual);
        }
    }
}
