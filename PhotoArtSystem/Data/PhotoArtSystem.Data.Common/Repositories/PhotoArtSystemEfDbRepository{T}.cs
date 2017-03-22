namespace PhotoArtSystem.Data.Common.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using Bytes2you.Validation;
    using Models;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Common.DateTime;

    public class PhotoArtSystemEfDbRepository<T> : IPhotoArtSystemEfDbRepository<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        public PhotoArtSystemEfDbRepository(DbContext context)
        {
            Guard.WhenArgument(
                context,
                GlobalConstants.DbContextRequiredExceptionMessage).IsNull().Throw();

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        private IDbSet<T> DbSet { get; set; }

        private DbContext Context { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return this.DbSet.Where(x => !x.IsDeleted);
        }

        public virtual IQueryable<T> GetAllWithDeleted()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Create(T entity)
        {
            var entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            var entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = GlobalDateTimeInfo.GetDateTimeUtcNow();
        }

        public virtual void DeletePermanent(T entity)
        {
            var entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }
    }
}
