namespace PhotoArtSystem.Services.Data.Contracts
{
    /// <summary>
    /// Common Update service.
    /// </summary>
    /// <typeparam name="T">Must be IAuditInfo and IDeletableEntity.</typeparam>
    public interface IBaseUpdateService<T>
        where T : class
    {
        /// <summary>
        /// Update <"T">.
        /// </summary>
        /// <param name="entity"><"T"> to be updated.</param>
        void Update(T entity);
    }
}
