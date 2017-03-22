namespace PhotoArtSystem.Data.Common.Repositories
{
    using System.Linq;
    using Models;

    public interface IPhotoArtSystemEfDbRepository<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAllWithDeleted();

        T GetById(object id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeletePermanent(T entity);
    }
}
