namespace PhotoArtSystem.Tests.IntegrationTests
{
    using System.Data.Entity.Migrations;
    using Data;

    internal sealed class TestDbConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public TestDbConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}
