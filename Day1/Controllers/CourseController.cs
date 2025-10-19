using Day1.Models;
using Day1.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace Day1.Controllers
{
    public class CourseController : Controller
    {
        //Context c1 = new Context();
        ICouresRepository course;
        IDepartmentRepository department;

        public CourseController(ICouresRepository _course, IDepartmentRepository _department)
        {
            course   = _course;
            department = _department;
        }


        public IActionResult Index()
        {
            List<Course> courses = course.GetAll("Department");

            return View(courses);
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            CourseDepartmentViewModel CDVM = new CourseDepartmentViewModel();
            List<Department> departmentList = department.GetAll(null);
            CDVM.Departments = departmentList;

            return View(CDVM);
        }

        [HttpPost]
        public IActionResult AddCourse(CourseDepartmentViewModel courseDepartmentVM)
        {
            //Course course = new Course();

            
            if (ModelState.IsValid == true)
            {
                try
                {
                    Course Course = new Course();
                    Course.Name = courseDepartmentVM.Name;
                    Course.Hours = courseDepartmentVM.Hours;
                    Course.minDegree = courseDepartmentVM.minDegree;
                    Course.degree = courseDepartmentVM.degree;
                    Course.DepartmentID = courseDepartmentVM.DepartmentID;
                    course.Add(Course);
                    course.Save();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Data Base Error", ex.InnerException.Message);
                }

            }
            courseDepartmentVM.Departments = department.GetAll("");
            return View(courseDepartmentVM);
        }
        public ActionResult CheckDegree(int degree, int minDegree)
        {
            if (degree > minDegree)
            {
                return Json(true);
            }
            return Json(false);
        }

        public ActionResult CheckHours(int Hours)
        {
            if (Hours % 3 == 0)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult GetCourseByDeptId(int deptId)
        {
            List<Course> courses = course.GetCourseById(deptId);
            return Json(courses);
        }
    }
}
