using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Day1.Models
{
    public class MyMinLengthAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }
        public MyMinLengthAttribute(int minLength)
            { this.MinLength = minLength; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            CourseDepartmentViewModel? courseDepartmentViewModel = validationContext.ObjectInstance as CourseDepartmentViewModel;
            if (value == null)
                return ValidationResult.Success;
            string? newName = value.ToString();
            if(newName.Length <MinLength )
            {
                return new ValidationResult($"The {validationContext.DisplayName} must be at least {MinLength} letters long.");
            }
            return ValidationResult.Success;
        }

    }
}
