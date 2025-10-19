using Day1.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day1.ViewModel
{
    public class InstuctorCourseDepartmentsViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Img { get; set; }

        public int Salary { get; set; }

        public string? Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public Department Department { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }

        public List<Course> Courses { get; set; }
        public List<Department> Departments { get; set; }
    }
}
