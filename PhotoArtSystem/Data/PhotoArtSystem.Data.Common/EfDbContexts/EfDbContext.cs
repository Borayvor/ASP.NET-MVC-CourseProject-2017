namespace PhotoArtSystem.Data.Common.EfDbContexts
{
    using System;
    using System.Data.Entity;
    using PhotoArtSystem.Common.Constants;

    public class EfDbContext : IEfDbContext
    {
        public EfDbContext(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(GlobalConstants.DbContextRequiredExceptionMessage);
            }

            this.Context = context;
        }

        private DbContext Context { get; set; }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}
