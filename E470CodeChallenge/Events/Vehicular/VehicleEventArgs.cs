using E470CodeChallenge.Entities;

namespace E470CodeChallenge.Events.Vehicular
{
    /// <summary>
    /// Used to pass arguments to the vehicle event.
    /// </summary>
    public class VehicleEventArgs
    {
        /// <summary>
        /// The constructor for the event arguments which requires a vehicle. 
        /// </summary>
        /// <param name="vehicle">The vehicle passed to the event execution. </param>
        public VehicleEventArgs(Vehicle vehicle) =>
            Vehicle = vehicle;

        /// <summary>
        /// Read only Vehicle property of the event arguments. 
        /// </summary>
        public Vehicle Vehicle { get; }
    }
}
