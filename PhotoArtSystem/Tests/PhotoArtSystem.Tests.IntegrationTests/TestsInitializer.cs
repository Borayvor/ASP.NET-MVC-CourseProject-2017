namespace PhotoArtSystem.Tests.IntegrationTests
{
    using System.Data.Entity;
    using Data;
    using NUnit.Framework;

    [SetUpFixture]
    public class TestsInitializer
    {
        [OneTimeSetUp]
        public static void AssemblyTestsInit()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, TestDbConfiguration>());
        }
    }
}
