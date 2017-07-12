namespace PhotoArtSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using PhotoArtSystem.Common.DateTime;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Information> Informations { get; set; }

        public IDbSet<Photocourse> Photocourses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Multimedia> Multimedia { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();

            return base.SaveChanges();
        }

        public async override Task<int> SaveChangesAsync()
        {
            this.ApplyAuditInfoRules();

            return await base.SaveChangesAsync();
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
                    entity.CreatedOn = ServerDateTime.Now();
                }
                else
                {
                    entity.ModifiedOn = ServerDateTime.Now();
                }
            }
        }
    }
}
