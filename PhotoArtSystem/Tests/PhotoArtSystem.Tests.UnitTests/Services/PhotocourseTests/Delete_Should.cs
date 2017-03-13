namespace PhotoArtSystem.Tests.UnitTests.Services.PhotocourseTests
{
    using Common.Constants;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models.Contracts;
    using PhotoArtSystem.Services.Photocourse;

    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_Photocourse_IsNull()
        {
            // Arange
            var mockedEfDbContext = new Mock<IEfDbContext>();
            var mockedIEfDbRepository = new Mock<IEfDbRepository<IPhotocourse>>();
            var mockedPhotocourseService = new PhotocourseService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act & Assert
            Assert.That(
                () => mockedPhotocourseService.Delete(null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.PhotocourseRequiredExceptionMessage));
        }

        [Test]
        public void CallOnce_EfDbContextSave_When_Photocourse_IsNotNull()
        {
            // Arange
            var mockedModel = new Mock<IPhotocourse>();
            var mockedEfDbContext = new Mock<IEfDbContext>();
            var mockedIEfDbRepository = new Mock<IEfDbRepository<IPhotocourse>>();
            var mockedPhotocourseService = new PhotocourseService(mockedEfDbContext.Object, mockedIEfDbRepository.Object);

            // Act
            mockedPhotocourseService.Delete(mockedModel.Object);

            // Assert
            mockedEfDbContext.Verify(x => x.Save(), Times.Once);
        }
    }
}
