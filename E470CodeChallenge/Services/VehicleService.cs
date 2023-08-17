using E470CodeChallenge.Entities;
using E470CodeChallenge.Events.Vehicular;
using E470CodeChallenge.Repositories;

namespace E470CodeChallenge.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILogger<VehicleService> _logger;

        /// <inheritdoc/>
        public event VehicleEvent? VehicleCreated;
        
        /// <summary>
        /// Constructor for the Vehicle Service.
        /// </summary>
        /// <param name="repository">The Vehicle Repository.</param>
        /// <param name="logger">The logger.</param>
        public VehicleService(
            IVehicleRepository repository,
            ILogger<VehicleService> logger) 
        { 
            _vehicleRepository = repository;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            string method = $"{nameof(VehicleService)}.{nameof(Create)}";
            
            //Errors are logged with stack trace, exceptions are thrown here for exception logs. 
            _logger.LogTrace($"Executing {method}.");
            
            if (VehicleCreated is null)
            {
                _logger.LogTrace($"{method}: VehicleCreatedEvent is null and required.");
                throw new InvalidOperationException("The vehicle service must have a created event to execute");
            }           
            
            //The following code is not supported by in memory db, leaving transactions out for challenge
            //await using var transaction = await _vehicleRepository.BeginTransactionAsync();

            _logger.LogTrace($"{method}: Transaction Started.");
            try
            {
                // Create vehicle and save.
                _vehicleRepository.Create(vehicle);
                await _vehicleRepository.SaveAsync();
                _logger.LogTrace($"{method}: Vehicle Saved.");
                
                //Call event
                await VehicleCreated(new VehicleEventArgs(vehicle));
                _logger.LogTrace($"{method}: Vehicle Event Executed.");
            }
            catch(Exception ex) 
            {
                //The following code is not supported by in memory db, leaving transactions out for challenge
                //await transaction.RollbackAsync();
                _logger.LogTrace(ex,$"{method}: Transaction RollBack.");
                throw; //Logging occurs in calling method for errors.
            }

            //The following code is not supported by in memory db, leaving transactions out for challenge
            //await transaction.CommitAsync();
            _logger.LogTrace($"{method} Transaction Commited -- Success.");

            return vehicle;
        }
    }
}
