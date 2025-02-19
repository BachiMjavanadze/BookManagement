using System.ComponentModel.DataAnnotations;

namespace BookManagement.Core.Attributes;

public class NotInFutureAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is int year)
        {
            if (year > DateTime.Now.Year)
            {
                return new ValidationResult($"Publication year cannot be in the future (max allowed is {DateTime.Now.Year}).");
            }
        }
        return ValidationResult.Success;
    }
}
