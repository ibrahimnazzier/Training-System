using System.ComponentModel.DataAnnotations;

namespace Day1.Models
{
    public class DividedByAttribute : ValidationAttribute
    {
        public int DividedBy { get; set; }
        public DividedByAttribute(int dividedBy) {
            DividedBy = dividedBy;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
             int DividedBy = (int)value;
            if (DividedBy % 3 == 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"{validationContext.MemberName} Should be divisible by 3");
        }
    }
}
