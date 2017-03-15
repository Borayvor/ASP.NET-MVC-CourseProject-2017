namespace PhotoArtSystem.Tests.UnitTests.Controllers.Global
{
    using System.Web.Mvc;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Services.Photocourse.Contracts;
    using Web.Controllers;

    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            var mockedPhotocourseService = new Mock<IPhotocourseService>();
            HomeController controller = new HomeController(mockedPhotocourseService.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void About()
        {
            // Arrange
            var mockedPhotocourseService = new Mock<IPhotocourseService>();
            HomeController controller = new HomeController(mockedPhotocourseService.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Contact()
        {
            // Arrange
            var mockedPhotocourseService = new Mock<IPhotocourseService>();
            HomeController controller = new HomeController(mockedPhotocourseService.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
