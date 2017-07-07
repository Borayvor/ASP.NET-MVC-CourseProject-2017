namespace PhotoArtSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IApplicationDbContext
    {
        IDbSet<Information> Informations { get; set; }

        IDbSet<Photocourse> Photocourses { get; set; }

        IDbSet<Student> Students { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Multimedia> Multimedia { get; set; }

        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}