namespace E470CodeChallenge.Entities
{
    
    /// <summary>
    /// The transponder Entity.
    /// </summary>
    public class Transponder : Entity
    {
        /// <summary>
        /// A unique identifier for the transponder.
        /// </summary>
        public long Id { get; set; }
       
        /// <summary>
        /// The unique vehicle id assigned to this transponder. 
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// The vehicle in which the transponder is linked. This exists to allow a foriegn key in EF setup, it is not in UML.
        /// </summary>
        public Vehicle? Vehicle { get; set; }
    }
}
