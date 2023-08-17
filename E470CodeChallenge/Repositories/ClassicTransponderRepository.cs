using E470CodeChallenge.DbContexts;
using E470CodeChallenge.Entities;

namespace E470CodeChallenge.Repositories
{
    public class ClassicTransponderRepository : Repository<Transponder>, ITransponderRepository
    {
        /// <summary>
        /// constructor for the Classic Transponder Repository to pass the context to the base class
        /// </summary>
        /// <param name="dbContext">The db context used by the repository</param>
        public ClassicTransponderRepository(E470DbContext dbContext) : base(dbContext) { }
    }
}
