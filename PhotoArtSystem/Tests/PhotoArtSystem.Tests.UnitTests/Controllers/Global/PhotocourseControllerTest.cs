namespace PhotoArtSystem.Tests.UnitTests.Controllers.Global
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using PhotoArtSystem.Services.Data.Contracts;
    using PhotoArtSystem.Services.Web.Contracts;
    using Ploeh.AutoFixture;
    using Web.Controllers;
    using Web.ViewModels.PhotocourseModels;

    [TestFixture]
    public class PhotocourseControllerTest
    {
        [Test]
        public void Index_ViewResult_Should_NotBeNull_WhenControllerArgumentsAre_NotNull()
        {
            // Arrange
            var mockedPhotocourseService = new Mock<IPhotocourseService>();
            var mockedAutoMapperService = new Mock<IAutoMapperService>();
            var mockedHttpCacheService = new Mock<ICacheService>();

            var controller = new PhotocourseController(
                mockedPhotocourseService.Object,
                mockedAutoMapperService.Object,
                mockedHttpCacheService.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Details_ViewResult_Should_NotBeNull_WhenControllerArgumentsAre_NotNull()
        {
            // Arrange
            Fixture fixture = new Fixture();
            var id = fixture.Create<Guid>();
            var mockedPhotocourseService = new Mock<IPhotocourseService>();
            var mockedAutoMapperService = new Mock<IAutoMapperService>();
            var mockedHttpCacheService = new Mock<ICacheService>();

            var controller = new PhotocourseController(
                mockedPhotocourseService.Object,
                mockedAutoMapperService.Object,
                mockedHttpCacheService.Object);

            // Act
            ViewResult result = controller.Details(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllPhotocourses_PartialViewResult_Should_NotBeNull_WhenArgumentsAre_NotNull()
        {
            // Arrange
            var mockedPhotocourseService = new Mock<IPhotocourseService>();
            var mockedAutoMapperService = new Mock<IAutoMapperService>();
            var mockedHttpCacheService = new Mock<ICacheService>();
            var partialView = new PartialViewResult();

            mockedPhotocourseService.Setup(x => x.GetAll()).Returns(It.IsAny<IEnumerable<PhotocourseTransitional>>());

            mockedAutoMapperService.Setup(x => x.Map<IEnumerable<PhotocourseViewModel>>(It.IsAny<IEnumerable<PhotocourseTransitional>>()))
                .Returns(It.IsAny<IEnumerable<PhotocourseViewModel>>());

            mockedHttpCacheService.Setup(x => x.Get(
                It.IsAny<string>(),
                It.IsAny<Func<PartialViewResult>>(),
                It.IsAny<uint>()))
                .Returns(partialView);

            var controller = new PhotocourseController(
                mockedPhotocourseService.Object,
                mockedAutoMapperService.Object,
                mockedHttpCacheService.Object);

            // Act
            PartialViewResult result = controller.GetAllPhotocourses() as PartialViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetPhotocourse_PartialViewResult_Should_NotBeNull_WhenArgumentsAre_NotNull()
        {
            // Arrange
            Fixture fixture = new Fixture();
            var id = fixture.Create<Guid>();
            var mockedPhotocourseService = new Mock<IPhotocourseService>();
            var mockedAutoMapperService = new Mock<IAutoMapperService>();
            var mockedHttpCacheService = new Mock<ICacheService>();
            var partialView = new PartialViewResult();

            mockedPhotocourseService.Setup(x => x.GetById(id)).Returns(It.IsAny<PhotocourseTransitional>());

            mockedAutoMapperService.Setup(x => x.Map<PhotocourseDetailsViewModel>(It.IsAny<PhotocourseTransitional>()))
                .Returns(It.IsAny<PhotocourseDetailsViewModel>());

            mockedHttpCacheService.Setup(x => x.Get(
                It.IsAny<string>(),
                It.IsAny<Func<PartialViewResult>>(),
                It.IsAny<uint>()))
                .Returns(partialView);

            var controller = new PhotocourseController(
                mockedPhotocourseService.Object,
                mockedAutoMapperService.Object,
                mockedHttpCacheService.Object);

            // Act
            PartialViewResult result = controller.GetPhotocourse(id) as PartialViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
