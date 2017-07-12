namespace PhotoArtSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Seeders;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
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
            StaticDataSeeder.SeedInformation(context);
            StaticDataSeeder.SeedStudents(context);
            StaticDataSeeder.SeedMultimedia(context);
        }
    }
}
