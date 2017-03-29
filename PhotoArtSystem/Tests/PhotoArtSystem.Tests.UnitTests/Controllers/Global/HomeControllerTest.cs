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
    using Web.Controllers;
    using Web.ViewModels.MainInfoModels;

    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index_ViewResult_Should_NotBeNull_WhenControllerArgumentsAre_NotNull()
        {
            // Arrange
            var mockedMainInfoService = new Mock<IMainInfoService>();
            var mockedPhotocourseService = new Mock<IPhotocourseService>();
            var mockedAutoMapperService = new Mock<IAutoMapperService>();
            var mockedHttpCacheService = new Mock<ICacheService>();

            var controller = new HomeController(
                mockedMainInfoService.Object,
                mockedPhotocourseService.Object,
                mockedHttpCacheService.Object,
                mockedAutoMapperService.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetCarouselData_PartialViewResult_Should_NotBeNull_WhenArgumentsAre_NotNull()
        {
            // Arrange
            var mockedMainInfoService = new Mock<IMainInfoService>();
            var mockedPhotocourseService = new Mock<IPhotocourseService>();
            var mockedAutoMapperService = new Mock<IAutoMapperService>();
            var mockedHttpCacheService = new Mock<ICacheService>();
            var partialView = new PartialViewResult();

            mockedPhotocourseService.Setup(x => x.GetAll()).Returns(It.IsAny<IEnumerable<PhotocourseTransitional>>());

            mockedAutoMapperService.Setup(x => x.Map<IEnumerable<CarouselDataViewModel>>(It.IsAny<IEnumerable<PhotocourseTransitional>>()))
                .Returns(It.IsAny<IEnumerable<CarouselDataViewModel>>());

            mockedHttpCacheService.Setup(x => x.Get(
                It.IsAny<string>(),
                It.IsAny<Func<PartialViewResult>>(),
                It.IsAny<uint>()))
                .Returns(partialView);

            var controller = new HomeController(
                mockedMainInfoService.Object,
                mockedPhotocourseService.Object,
                mockedHttpCacheService.Object,
                mockedAutoMapperService.Object);

            // Act
            PartialViewResult result = controller.GetCarouselData() as PartialViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetPhotoArtInfos_PartialViewResult_Should_NotBeNull_WhenArgumentsAre_NotNull()
        {
            // Arrange
            var mockedMainInfoService = new Mock<IMainInfoService>();
            var mockedPhotocourseService = new Mock<IPhotocourseService>();
            var mockedAutoMapperService = new Mock<IAutoMapperService>();
            var mockedHttpCacheService = new Mock<ICacheService>();
            var partialView = new PartialViewResult();

            mockedMainInfoService.Setup(x => x.GetAll()).Returns(It.IsAny<IEnumerable<MainInfoTransitional>>());

            mockedAutoMapperService.Setup(x => x.Map<IEnumerable<MainInfoViewModel>>(It.IsAny<IEnumerable<MainInfoTransitional>>()))
                .Returns(It.IsAny<IEnumerable<MainInfoViewModel>>());

            mockedHttpCacheService.Setup(x => x.Get(
                It.IsAny<string>(),
                It.IsAny<Func<PartialViewResult>>(),
                It.IsAny<uint>()))
                .Returns(partialView);

            var controller = new HomeController(
                mockedMainInfoService.Object,
                mockedPhotocourseService.Object,
                mockedHttpCacheService.Object,
                mockedAutoMapperService.Object);

            // Act
            PartialViewResult result = controller.GetPhotoArtInfos() as PartialViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
