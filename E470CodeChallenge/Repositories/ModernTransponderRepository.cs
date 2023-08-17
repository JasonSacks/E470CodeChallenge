using E470CodeChallenge.DbContexts;
using E470CodeChallenge.Entities;
using E470CodeChallenge.Repositories;

namespace E470CodeChallenge.Repositories
{
    public class ModernTransponderRepository : Repository<Transponder>, ITransponderRepository
    {
        /// <summary>
        /// constructor for the Modern Transponder Repository to pass the context to the base class
        /// </summary>
        /// <param name="dbContext">The db context used by the repository</param>
        public ModernTransponderRepository(E470DbContext dbContext) : base(dbContext) { }


    }
}

