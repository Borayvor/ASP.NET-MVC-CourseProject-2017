namespace PhotoArtSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.PhotocourseModels;
    using PhotoArtSystem.Common.DateTime;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<PhotoArtService> PhotoArtServices { get; set; }

        public IDbSet<Lesson> Lessons { get; set; }

        public IDbSet<OriginalImage> OriginalImages { get; set; }

        public IDbSet<PhotocourseGroup> PhotocourseGroups { get; set; }

        public IDbSet<Photocourse> Photocourses { get; set; }

        public IDbSet<ImageLink> ImageLinks { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();

            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageLink>().HasKey(m => m.Id);

            modelBuilder.Entity<PhotocourseGroup>()
                .HasRequired(m => m.ImageLink)
                .WithRequiredPrincipal(m => m.PhotocourseGroup);

            base.OnModelCreating(modelBuilder);
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = GlobalDateTimeInfo.GetDateTimeUtcNow();
                }
                else
                {
                    entity.ModifiedOn = GlobalDateTimeInfo.GetDateTimeUtcNow();
                }
            }
        }
    }
}
