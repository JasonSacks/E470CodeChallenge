using System.ComponentModel.DataAnnotations;

namespace E470CodeChallenge.Attributes
{
    [AttributeUsage(AttributeTargets.Property |  AttributeTargets.Field, AllowMultiple = false)] 
    public sealed class ValidateYearAttribute : ValidationAttribute
    {
        
        /// <summary>
        /// Overridden to provide custom validation for the year of a vehicle. 
        /// </summary>
        /// <param name="value">The value that is to be validated.</param>
        /// <returns>True if valid, false if not valid.</returns>
        public override bool IsValid(object? value)
        {
            //Do not validate if we do not have a value, just return true. Leave required to other attributes.
            if (value is null)
            {
                return true;
            }

            bool result = true;
            string? stringValue = value as string;
            
            // If we converted to string with the as, then ensure the length is 4 digits.
            if (stringValue?.Length != 4)
            {
                ErrorMessage = $"The value {value} must be a 4 digit string value.";
                result = false;
            };

            if (!short.TryParse(stringValue ?? "", out short yearNumber))
            {
                ErrorMessage = $"The value {value} must be a number.";
                result = false;
            }

            // Assumed transponders are for motortized vehicles, 1885 is first motorcylce,
            // new vehicles commonly are a year beyond current year. Logic would need to be determined as business decides. 
            if (yearNumber < 1885 || yearNumber > DateTime.UtcNow.Year + 1)
            {
                ErrorMessage = $"The value {value} must be between 1885 and next year.";
                result = false;
            }
            return result;
        }
    }
}
