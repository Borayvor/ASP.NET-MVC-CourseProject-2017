namespace PhotoArtSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models.PhotocourseModels;

    public interface IApplicationDbContext
    {
        IDbSet<Photocourse> Photocourses { get; set; }

        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}