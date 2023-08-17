using E470CodeChallenge.Entities;
using E470CodeChallenge.Events.Vehicular;

namespace E470CodeChallenge.Services
{
    public interface IVehicleService
    {
        /// <summary>
        /// Nullable VehicleEvent. 
        /// </summary>
        event VehicleEvent? VehicleCreated;

        /// <summary>
        /// Asynchronous Call to Create the vehicle
        /// </summary>
        /// <param name="vehicle">The vehicle to create.</param>
        /// <returns>A Task holding the vehicle result object.</returns>
        Task<Vehicle> Create(Vehicle vehicle);
    }
}
 