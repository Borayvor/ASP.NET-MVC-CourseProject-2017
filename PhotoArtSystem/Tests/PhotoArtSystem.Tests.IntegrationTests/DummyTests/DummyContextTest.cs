namespace PhotoArtSystem.Tests.IntegrationTests.DummyTests
{
    using System.Linq;
    using Autofac;
    using Data;
    using NUnit.Framework;

    [TestFixture]
    public class DummyContextTest
    {
        private IContainer autofacContainer;

        protected IContainer AutofacContainer
        {
            get
            {
                if (this.autofacContainer == null)
                {
                    var builder = new ContainerBuilder();

                    builder.RegisterType<ApplicationDbContext>()
                        .As<ApplicationDbContext>()
                        .InstancePerLifetimeScope();

                    var container = builder.Build();

                    this.autofacContainer = container;
                }

                return this.autofacContainer;
            }
        }

        protected ApplicationDbContext ContextDb
        {
            get
            {
                return this.AutofacContainer.Resolve<ApplicationDbContext>();
            }
        }

        [Test]
        public void Db_Should_HaveOnlyOneUser_WithSuchEmail()
        {
            // Arrange
            var email = "admin@admin.com";

            // Act
            int usersCount = this.ContextDb.Users.Where(x => x.Email == email).Count();

            // Assert
            Assert.AreEqual(1, usersCount);
        }
    }
}
