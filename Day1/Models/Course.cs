using System.ComponentModel.DataAnnotations.Schema;

namespace Day1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int degree { get; set; }

        public int minDegree { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID {  get; set; }
        public Department Department { get; set; }

        public ICollection<crsResult> CrsResult { get; set; }

        public ICollection<Instructor> Instructors { get; set; }

        public int Hours { get; set; }

    }
}
