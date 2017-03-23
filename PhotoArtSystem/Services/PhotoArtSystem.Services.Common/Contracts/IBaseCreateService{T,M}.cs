namespace PhotoArtSystem.Services.Common.Contracts
{
    using Data.Common.Models;

    /// <summary>
    /// Common Create service.
    /// </summary>
    /// <typeparam name="T">Must be IAuditInfo and IDeletableEntity.</typeparam>
    public interface IBaseCreateService<T, M>
        where T : IAuditInfo, IDeletableEntity
        where M : class
    {
        /// <summary>
        /// Create new <"T">.
        /// </summary>
        /// <param name="content"><"T"> to be created.</param>
        void Create(M entity);
    }
}
