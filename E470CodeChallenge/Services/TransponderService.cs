using E470CodeChallenge.Entities;
using E470CodeChallenge.Events.Vehicular;
using E470CodeChallenge.Factories;
using E470CodeChallenge.Repositories;

namespace E470CodeChallenge.Services
{
    /// <summary>
    /// The Transponder Service used to manage transponder logic
    /// </summary>
    public class TransponderService : ITransponderService
    {
        private readonly ITransponderRepositoryFactory _repositoryFactory;
        private readonly ILogger _logger;
        
        /// <summary>
        /// Constructor for the Transponder Service.
        /// </summary>
        /// <param name="factory">The factory for creating the correct TransponderRepository.</param>
        /// <param name="logger">The logger.</param>
        public TransponderService(
            ITransponderRepositoryFactory factory,
            ILogger<TransponderService> logger)
        {
            _repositoryFactory = factory;
            _logger = logger;
        }

        public async Task<Transponder> Create(Vehicle vehicle)
        {
            string method = $"{nameof(TransponderService)}.{nameof(Create)}";
            _logger.LogTrace($"{method}: Executing");

            if (vehicle.Year?.Length != 4 || !short.TryParse(vehicle.Year, out short vehicleYear) || 
                vehicleYear < 1885 || vehicleYear > DateTime.UtcNow.Year + 1)
            {
                _logger.LogTrace($"{method}: Year is invalid");

                throw new ArgumentException("The vehicle year is invalid and must be formatted as a 4 digit string and a valid range for vehicle.");
            }
            
            // Get the repository and create the object
            ITransponderRepository repository = _repositoryFactory.GetTransponderRepository(vehicleYear);
            _logger.LogTrace($"{method}: Transponder Repository Resolved.");

            Transponder entity = new()
            {
                VehicleId = vehicle.Id
            };
            
            // Create the entity and save it
            repository.Create(entity);
            _logger.LogTrace($"{method}: Creating Transponder.");

            await repository.SaveAsync();
            _logger.LogTrace($"{method}: Saving Transponder -- Success");

            return entity;
        }

        public async Task OnVehicleCreated(VehicleEventArgs arguments)
        {
            _logger.LogTrace($"{nameof(TransponderService)}.{nameof(OnVehicleCreated)} : Async func returned from event handler");
            // we return the task rather than await for 
            await Create(arguments.Vehicle);
        } 
            
        
    }
}
