using System.ComponentModel.DataAnnotations.Schema;

namespace Day1.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }

        public string? Address { get; set; }

        public int grade { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        
        public ICollection<crsResult> CrsResult { get; set; }
    }
}
