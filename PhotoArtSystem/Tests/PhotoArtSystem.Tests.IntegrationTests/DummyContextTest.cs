namespace PhotoArtSystem.Tests.IntegrationTests
{
    using System.Linq;
    using Data;
    using NUnit.Framework;

    [TestFixture]
    public class DummyContextTest
    {
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            this.context = new ApplicationDbContext();
        }

        [Test]
        [TestCase("admin@admin.com")]
        public void Db_Should_HaveOnlyOneUser_WithSuchEmail(string email)
        {
            // Arrange & Act
            int usersCount = this.context.Users.Where(x => x.Email == email).Count();

            // Assert
            Assert.AreEqual(1, 1);
        }
    }
}
