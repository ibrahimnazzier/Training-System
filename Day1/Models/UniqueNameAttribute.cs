using System.ComponentModel.DataAnnotations;

namespace Day1.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            CourseDepartmentViewModel? courseDepartmentViewModel = validationContext.ObjectInstance as CourseDepartmentViewModel;
            if (value == null)
                return null;
            string? newName = value.ToString();
            Context context = validationContext.GetRequiredService<Context>();
            if (courseDepartmentViewModel== null)
                return null;
            if (courseDepartmentViewModel.DepartmentID == 0)
                return new ValidationResult("Plz enter the department ID");

            Course? course=context.Course
                .FirstOrDefault(c => c.Name == newName && courseDepartmentViewModel.DepartmentID == c.DepartmentID);

            if(course == null)
            {

                return ValidationResult.Success;
            }
            return new ValidationResult("Name Must be Unique.");
        }
    }
}
