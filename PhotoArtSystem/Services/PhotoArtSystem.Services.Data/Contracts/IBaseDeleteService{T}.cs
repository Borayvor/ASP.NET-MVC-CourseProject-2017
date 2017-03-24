namespace PhotoArtSystem.Services.Data.Contracts
{
    /// <summary>
    /// Common Delete service.
    /// </summary>
    /// <typeparam name="T">Must be IAuditInfo and IDeletableEntity.</typeparam>
    public interface IBaseDeleteService<T>
        where T : class
    {
        /// <summary>
        /// Delete <"T">. Not permanent.
        /// </summary>
        /// <param name="entity"><"T"> to be deleted (Not permanent).</param>
        void Delete(T entity);
    }
}
