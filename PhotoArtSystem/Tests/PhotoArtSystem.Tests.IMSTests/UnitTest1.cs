namespace PhotoArtSystem.Tests.IMSTests
{
    using System.Linq;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            ApplicationDbContext context = new ApplicationDbContext();

            // Act
            int usersCount = context.Users.Count();

            // Assert
            Assert.AreEqual(1, usersCount);
        }
    }
}
