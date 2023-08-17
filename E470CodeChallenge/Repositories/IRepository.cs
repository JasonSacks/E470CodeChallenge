using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using E470CodeChallenge.Entities;

namespace E470CodeChallenge.Repositories
{
    /// <summary>
    /// The repository interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T: Entity
    {
        
        /// <summary>
        /// Creates the entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be created.</param>
        void Create(T entity);

        /// <summary>
        /// Saves the changes in the context.
        /// </summary>
        /// <returns>An empty task for async processing.</returns>
        Task SaveAsync();

        /// <summary>
        /// Begins a transaction in the database. For the purpose of this code challenge, I am injecting the context as scoped to 
        /// ensure the same context happens per request rather than a separate context instance injected for each repository.
        /// </summary>
        /// <returns>The IDbContextTransaction for management of the created transaction.</returns>
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}

