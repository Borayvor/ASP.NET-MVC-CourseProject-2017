namespace PhotoArtSystem.Services.Common.Contracts
{
    using Data.Common.Models;

    /// <summary>
    /// Common Update service.
    /// </summary>
    /// <typeparam name="T">Must be IAuditInfo and IDeletableEntity.</typeparam>
    public interface IBaseUpdateService<T, M>
        where T : IAuditInfo, IDeletableEntity
        where M : class
    {
        /// <summary>
        /// Update <"T">.
        /// </summary>
        /// <param name="entity"><"T"> to be updated.</param>
        void Update(M entity);
    }
}
