namespace PhotoArtSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;
    using Models.PhotocourseModels;

    public interface IApplicationDbContext
    {
        IDbSet<PhotoArtService> PhotoArtServices { get; set; }

        IDbSet<Photocourse> Photocourses { get; set; }

        IDbSet<PhotocourseGroup> PhotocourseGroups { get; set; }

        IDbSet<Lesson> Lessons { get; set; }

        IDbSet<ImageLink> ImageLinks { get; set; }

        IDbSet<OriginalImage> OriginalImages { get; set; }

        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}