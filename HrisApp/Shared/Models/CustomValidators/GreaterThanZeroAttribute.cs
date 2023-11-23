using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.CustomValidators
{
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
