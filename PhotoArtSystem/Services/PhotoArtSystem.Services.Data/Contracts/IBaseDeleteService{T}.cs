namespace PhotoArtSystem.Services.Data.Contracts
{
    using PhotoArtSystem.Data.Common.Models;

    /// <summary>
    /// Common Delete service.
    /// </summary>
    /// <typeparam name="T">Type of entity. Must be IAuditInfo and IDeletableEntity.</typeparam>
    public interface IBaseDeleteService<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Delete <"T">. Not permanent.
        /// </summary>
        /// <param name="entity"><"T"> to be deleted (Not permanent).</param>
        void Delete(T entity);
    }
}
