namespace PhotoArtSystem.Services.Data.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Common Get service.
    /// </summary>
    /// <typeparam name="T">Must be IAuditInfo and IDeletableEntity.</typeparam>
    /// <typeparam name="I">Must be struct or string.</typeparam>
    public interface IBaseGetService<T, I>
        where T : class
    {
        /// <summary>
        /// Get all <"T">. Without ordinary deleted.
        /// </summary>
        /// <returns> Return <"T"> as enumerable. </returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets the <"T"> by id.
        /// </summary>
        /// <param name="id">The id of the <"T"> as <"I"> to get.</param>
        /// <returns>Return <"T"> with id <"I"></returns>
        T GetById(I id);
    }
}
