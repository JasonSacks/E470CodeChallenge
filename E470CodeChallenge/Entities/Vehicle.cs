using E470CodeChallenge.Attributes;
using System.ComponentModel.DataAnnotations;

namespace E470CodeChallenge.Entities
{
    /// <summary>
    /// The Vehicle Entity.
    /// </summary>
    public class Vehicle : Entity
    {
        /// <summary>
        /// A unique identifier for the vehicle.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// The make of the vehicle. This field is required; this is not part of the specification, 
        /// but allowing all nulls can make the info meaningless. This would normally be a quetion I would ask (required fields?).
        /// </summary>
        [Required]
        public string? Make { get; set; }

        /// <summary>
        /// The Model of the vehicle. This field is required; this is not part of the specification, 
        /// but allowing all nulls can make the info meaningless. This would normally be a quetion I would ask (required fields?).
        /// </summary>
        [Required]
        public string? Model { get; set; }

        /// <summary>
        /// The year of the vehicle.This field is required; this is not part of the specification, 
        /// but allowing all nulls can make the info meaningless. This would normally be a quetion I would ask (required fields?).
        /// </summary>
        [Required]
        public string? Year { get; set; }

        /// <summary>
        /// The transponder that is linked to the Vehicle. 
        /// </summary>
        public Transponder? Transponder { get; set; }
    }
}
