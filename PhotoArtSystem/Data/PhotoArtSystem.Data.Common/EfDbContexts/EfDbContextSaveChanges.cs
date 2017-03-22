namespace PhotoArtSystem.Data.Common.EfDbContexts
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using PhotoArtSystem.Common.Constants;

    public class EfDbContextSaveChanges : IEfDbContextSaveChanges
    {
        public EfDbContextSaveChanges(DbContext context)
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

        public Task<int> SaveAsync()
        {
            return this.Context.SaveChangesAsync();
        }
    }
}
