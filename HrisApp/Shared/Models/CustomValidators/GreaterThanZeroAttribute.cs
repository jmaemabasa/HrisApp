using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.CustomValidators
{
#nullable disable
    public class GreaterThanZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int intValue && intValue != 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Please select.");
        }
    }
}
