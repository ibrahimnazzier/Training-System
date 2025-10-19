using Day1.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day1.ViewModel
{
    public class CourseDepartmentViewModel
    {
        [Display(Name = "Course Name")]
        [Required]
        [UniqueName]
        [MyMinLength(3)]
        public string Name { get; set; }

        [Display(Name = "Course's Passing Degree")]
        [Required]
        public int minDegree { get; set; }

        [Display(Name = "Course Degree")]
        [Required]
        [Range(50,100)]
        [Remote(action:"CheckDegree",controller: "Course", ErrorMessage =$"Degree should be more than The Min Degree",AdditionalFields = nameof(minDegree)) ]
        public int degree { get; set; }



        [Display(Name = "Course's Department")]
        [Required]
        public int DepartmentID { get; set; }

        [Display(Name = "Courses' Hours")]
        [Required]
        [DividedBy(3)]
        [Remote(action: "CheckHours", controller: "Course", ErrorMessage ="This degree is not divisble by 3")]
        public int Hours { get; set; }


        public List<Department>? Departments { get; set; }

        public Department? Department { get; set; }

    }
}

