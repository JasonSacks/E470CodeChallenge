using E470CodeChallenge.DbContexts;
using E470CodeChallenge.Repositories;

namespace E470CodeChallenge.Factories
{
    public class TransponderRepositoryFactory : ITransponderRepositoryFactory
    {
        
        private readonly E470DbContext _dbContext;

        /// <summary>
        /// Constructor for the factory.
        /// </summary>
        /// <param name="dbContext">The context used by the repository</param>
        public TransponderRepositoryFactory(E470DbContext dbContext) =>
            _dbContext = dbContext;
        
        /// <inheritdoc/>        
        public ITransponderRepository GetTransponderRepository(short year)
        {
            /**
             * Often UTC is used, and if not used would be a good idea if other states are supported in the future, though I 
               I understand that there may be laws of when a year has passed to determine if the car is classic. The logic 
               is outside of the scope of definition so I opted to use UTC now. 
            **/
            if (year <= DateTime.UtcNow.Year - 25)
            {
                return new ClassicTransponderRepository(_dbContext);
            }

            return new ModernTransponderRepository(_dbContext);
        }
    }
}
