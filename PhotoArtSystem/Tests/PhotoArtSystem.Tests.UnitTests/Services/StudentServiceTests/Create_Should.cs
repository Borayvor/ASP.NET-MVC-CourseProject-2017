namespace PhotoArtSystem.Tests.UnitTests.Services.StudentServiceTests
{
    using Common.Constants;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using PhotoArtSystem.Services.Data;
    using PhotoArtSystem.Services.Web.Contracts;

    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_Student_IsNull()
        {
            // Arange
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Student>>();
            var service = new StudentService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act & Assert
            Assert.That(
                () => service.Create(null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.StudentTransitionalRequiredExceptionMessage));
        }

        [Test]
        public void CallOnce_EfDbContextSave_When_Student_IsNotNull()
        {
            // Arange
            var mockedMapper = new Mock<IAutoMapperService>();
            var mockedEfDbContext = new Mock<IEfDbContextSaveChanges>();
            var mockedIEfDbRepository = new Mock<IPhotoArtSystemEfDbRepository<Student>>();
            var service = new StudentService(mockedMapper.Object, mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            service.Create(new StudentTransitional());

            // Assert
            mockedEfDbContext.Verify(x => x.Save(), Times.Once);
        }
    }
}
