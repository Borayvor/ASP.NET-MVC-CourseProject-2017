namespace PhotoArtSystem.Services.Data.Contracts
{
    using PhotoArtSystem.Data.Common.Models;

    /// <summary>
    /// Common Create service.
    /// </summary>
    /// <typeparam name="T">Type of entity. Must be IAuditInfo and IDeletableEntity.</typeparam>
    public interface IBaseCreateService<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Create new <"R">.
        /// </summary>
        /// <param name="entity"><"T"> to be created.</param>
        void Create(T entity);
    }
}
