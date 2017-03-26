namespace PhotoArtSystem.Tests.IntegrationTests
{
    using System.Data.Entity.Migrations;
    using Data;
    using Data.Seeders;

    internal sealed class TestDbConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public TestDbConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            StaticDataSeeder.SeedRoles(context);
            StaticDataSeeder.SeedUsers(context);

            StaticDataSeeder.SeedImages(context);
            StaticDataSeeder.SeedPhotocourses(context);
            StaticDataSeeder.SeedMainInfo(context);
            StaticDataSeeder.SeedStudents(context);
        }
    }
}
