using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day1.Models
{
    public class crsResult
    {
        public int Degree { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }
        
        [ForeignKey("Trainee")]
        public int TraineeID { get; set; }
        public Trainee Trainee { get; set; }
    }
}
