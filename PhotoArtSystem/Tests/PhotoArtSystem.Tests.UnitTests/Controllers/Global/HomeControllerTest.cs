namespace PhotoArtSystem.Tests.UnitTests.Controllers.Global
{
    using System.Web.Mvc;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Services.Web.Contracts;
    using Web.Controllers;

    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index_ViewResult_Should_NotBeNull_WhenControllerArgumentsAreNotNull()
        {
            // Arrange
            var mockedAutoMapperService = new Mock<IAutoMapperService>();
            var mockedHttpCacheService = new Mock<ICacheService>();

            HomeController controller = new HomeController(
                mockedAutoMapperService.Object,
                mockedHttpCacheService.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Contact_ViewResult_Should_NotBeNull_WhenControllerArgumentsAreNotNull()
        {
            // Arrange
            var mockedAutoMapperService = new Mock<IAutoMapperService>();
            var mockedHttpCacheService = new Mock<ICacheService>();

            HomeController controller = new HomeController(
                mockedAutoMapperService.Object,
                mockedHttpCacheService.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        ////[Test]
        ////public void GetPhotocourses_PartialViewResult_Should_NotBeNull_WhenArgumentsAreNotNull()
        ////{
        ////    // Arrange
        ////    var listPhotocourses = new List<Photocourse>()
        ////    {
        ////        new Photocourse()
        ////    };
        ////    var mockedPhotocourseService = new Mock<IPhotocourseService>();
        ////    var mockedAutoMapperService = new Mock<IAutoMapperService>();
        ////    var mockedAutoMapper = new Mock<IMapper>();
        ////    var mockedHttpCacheService = new Mock<ICacheService>();
        ////    var partialView = new PartialViewResult();

        ////    mockedPhotocourseService.Setup(x => x.GetAll()).Returns(listPhotocourses);
        ////    mockedAutoMapperService.Setup(x => x.GetAutoMapper).Returns(mockedAutoMapper.Object);
        ////    mockedHttpCacheService.Setup(x => x.Get(It.IsAny<string>(), It.IsAny<Func<PartialViewResult>>(), It.IsAny<int>())).Returns(partialView);

        ////    HomeController controller = new HomeController(
        ////        mockedPhotocourseService.Object,
        ////        mockedAutoMapperService.Object,
        ////        mockedHttpCacheService.Object);

        ////    // Act
        ////    PartialViewResult result = controller.GetPhotocourses() as PartialViewResult;

        ////    // Assert
        ////    Assert.IsNotNull(result);
        ////}
    }
}
