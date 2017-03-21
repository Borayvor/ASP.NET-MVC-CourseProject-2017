namespace PhotoArtSystem.Tests.IntegrationTests
{
    using System.Linq;
    using Data;
    using NUnit.Framework;

    [TestFixture]
    public class DummyContextTest
    {
        [Test]
        [TestCase("admin@admin.com")]
        public void Db_ShouldHaveOnlyOneUserWithSuchEmail(string email)
        {
            // Arrange
            ApplicationDbContext context = new ApplicationDbContext();

            // Act
            int usersCount = context.Users.Where(x => x.Email == email).Count();

            // Assert
            Assert.AreEqual(1, usersCount);
        }
    }
}
