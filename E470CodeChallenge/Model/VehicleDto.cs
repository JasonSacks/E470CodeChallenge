using E470CodeChallenge.Attributes;
using System.ComponentModel.DataAnnotations;

namespace E470CodeChallenge.Model
{
    /// <summary>
    /// Vehicle Dto class used for interacting with the controllers. 
    /// </summary>
    public class VehicleDto
    {
        /// <summary>
        /// The make of the vehicle. This field is required; this is not part of the specification, 
        /// but allowing all nulls can make the info meaningless. This would normally be a quetion I would ask (required fields?).
        /// </summary>
        [Required]
        public string? Make { get; set; }

        /// <summary>
        /// The Model of the vehicle.This field is required; this is not part of the specification, 
        /// but allowing all nulls can make the info meaningless. This would normally be a quetion I would ask (required fields?).
        /// </summary>
        [Required]
        public string? Model { get; set; }

        /// <summary>
        /// The year of the vehicle. This field is required; this is not part of the specification, 
        /// but allowing all nulls can make the info meaningless. This would normally be a quetion I would ask (required fields?).\
        /// A custom attribute is used to validate the year. 
        /// </summary>
        [Required]
        [ValidateYear]
        public string? Year { get; set; }
    }
}
