using System.ComponentModel.DataAnnotations.Schema;

namespace Day1.Models
{
    public class Instructor
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


    }
}
