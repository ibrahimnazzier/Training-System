using Day1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day1.Controllers
{
    public class InstructorController : Controller
    {
        Context c1 = new Context();

        public IActionResult Index()
        {
            List<Instructor> instructors = c1.Instructor.ToList();
            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            Instructor? instructor = c1.Instructor.Include(i => i.Department).FirstOrDefault(i => i.Id == id);
            if (instructor == null)
                return NotFound();
            else
            {
                return View(instructor);

            }
        }
        public IActionResult AddNewInstructor()
        {
            InstuctorCourseDepartmentsViewModel instuctorCourseDepartmentsViewModel = new();
            List<Course> courses = c1.Course.ToList();
            List<Department> departments  = c1.Department.ToList();
            instuctorCourseDepartmentsViewModel.Courses = courses;
            instuctorCourseDepartmentsViewModel.Departments = departments;
            return View(instuctorCourseDepartmentsViewModel);
        }

        public IActionResult Search(string name)
        {
            List<Instructor>? instructors = c1.Instructor
                .Include(d=>d.Department)
                .Include(c=>c.Course)
                .Where(i => i.Name.Contains(name)).ToList();
            if (instructors == null)
            {
                return NotFound();
            }
            return View("Index",instructors);
        }
        public IActionResult SaveNewInstructor(InstuctorCourseDepartmentsViewModel instructorVM)
        {
            Instructor instructor = new();
            if(instructorVM.Name != null 
                && instructorVM.Salary != 0 
                && instructorVM.Address != null 
                && instructorVM.DepartmentID !=0
                && instructorVM.Img != null
                && instructorVM.CourseID != 0)
            {
                instructor.Name = instructorVM.Name;
                instructor.Salary = instructorVM.Salary;
                instructor.CourseID = instructorVM.CourseID;
                instructor.DepartmentID = instructorVM.DepartmentID;
                instructor.Address = instructorVM.Address;
                instructor.Img = instructorVM.Img;
                c1.Instructor.Add(instructor);
                c1.SaveChanges();
                return  Redirect("Index");
            }
            //instructorVM.Courses = c1.Course.ToList();
            instructorVM.Departments = c1.Department.ToList();
            return View("AddNewInstructor", instructorVM);
        }
    }


    
}
