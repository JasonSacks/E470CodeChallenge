using E470CodeChallenge.Entities;
using E470CodeChallenge.Events.Vehicular;

namespace E470CodeChallenge.Services
{
    public interface ITransponderService
    {
        /// <summary>
        /// Creates a Transponder.
        /// </summary>
        /// <param name="vehicle">The Vehicle that the Transponder is created for.</param>
        /// <returns>A transponder as a task.</returns>
        Task<Transponder> Create(Vehicle vehicle);
        
        /// <summary>
        /// The event hanlder for the VehicleCreatedEvent. This event returns a func so I can keep the code async.
        /// </summary>
        /// <param name="arguments">The vehicle Event Arguments</param>
        /// <returns>A task for asynchronous call.</returns>
        Task OnVehicleCreated(VehicleEventArgs arguments);
    }
}
