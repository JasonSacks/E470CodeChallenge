using E470CodeChallenge.DbContexts;
using E470CodeChallenge.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace E470CodeChallenge.Repositories
{
    /// <summary>
    /// The abstract class for repositories. 
    /// </summary>
    /// <typeparam name="T">The table the repository pertains to.</typeparam>
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {

        private readonly E470DbContext _dbContext;
        private readonly DbSet<T> _table;

        /// <summary>
        /// Constructor used for instantiation of the base generic repository
        /// </summary>
        /// <param name="dbContext">The db context which is a non nullable parameter, rather than throwing argument null exception.</param>
        public Repository(E470DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }    
        
        /// <inheritdoc/>
        public virtual void Create(T entity) =>
            _table.Add(entity);

        /// <inheritdoc/>
        public virtual async Task SaveAsync() => 
            await _dbContext.SaveChangesAsync();

        /// <inheritdoc/>
        public virtual async Task<IDbContextTransaction> BeginTransactionAsync() =>
            await _dbContext.Database.BeginTransactionAsync();
    }
}