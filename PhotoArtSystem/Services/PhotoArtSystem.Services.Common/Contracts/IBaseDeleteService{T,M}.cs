namespace PhotoArtSystem.Services.Common.Contracts
{
    using Data.Common.Models;

    /// <summary>
    /// Common Delete service.
    /// </summary>
    /// <typeparam name="T">Must be IAuditInfo and IDeletableEntity.</typeparam>
    public interface IBaseDeleteService<T, M>
        where T : IAuditInfo, IDeletableEntity
        where M : class
    {
        /// <summary>
        /// Delete <"T">. Not permanent.
        /// </summary>
        /// <param name="entity"><"T"> to be deleted (Not permanent).</param>
        void Delete(M entity);
    }
}
