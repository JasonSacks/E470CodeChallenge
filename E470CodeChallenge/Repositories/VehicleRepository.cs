using E470CodeChallenge.DbContexts;
using E470CodeChallenge.Entities;

namespace E470CodeChallenge.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
{
        /// <summary>
        /// constructor for the Vehicle Repository to pass the context to the base class
        /// </summary>
        /// <param name="dbContext">The db context used by the repository</param>
        public VehicleRepository(E470DbContext dbContext) : base(dbContext) { }

    }
}
