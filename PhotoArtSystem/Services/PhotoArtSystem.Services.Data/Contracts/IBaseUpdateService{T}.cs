namespace PhotoArtSystem.Services.Data.Contracts
{
    using PhotoArtSystem.Data.Common.Models;

    /// <summary>
    /// Common Update service.
    /// </summary>
    /// <typeparam name="T">Type of entity. Must be IAuditInfo and IDeletableEntity.</typeparam>
    public interface IBaseUpdateService<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Update <"T">.
        /// </summary>
        /// <param name="entity"><"T"> to be updated.</param>
        void Update(T entity);
    }
}
