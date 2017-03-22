namespace PhotoArtSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IApplicationDbContext
    {
        IDbSet<Photocourse> Photocourses { get; set; }

        IDbSet<Student> PhotocourseGroups { get; set; }

        IDbSet<Image> ImageLinks { get; set; }

        IDbSet<OriginalImage> OriginalImages { get; set; }

        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}