namespace PhotoArtSystem.Services.Common.Contracts
{
    using System.Collections.Generic;
    using Data.Common.Models;

    /// <summary>
    /// Common Get service.
    /// </summary>
    /// <typeparam name="T">Must be IAuditInfo and IDeletableEntity.</typeparam>
    /// <typeparam name="I">Must be struct or string.</typeparam>
    public interface IBaseGetService<T, I, M>
        where T : IAuditInfo, IDeletableEntity
        where M : class
    {
        /// <summary>
        /// Get all <"T">. Without ordinary deleted.
        /// </summary>
        /// <returns> Return <"T"> as enumerable. </returns>
        IEnumerable<M> GetAll();

        /// <summary>
        /// Gets the <"M"> by id.
        /// </summary>
        /// <param name="id">The id of the <"T"> as <"I"> to get.</param>
        /// <returns>Return <"M"> with id <"I"></returns>
        M GetById(I id);
    }
}
