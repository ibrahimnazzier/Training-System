using Day1.Models;
using Day1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Day1.Controllers
{
    public class TraineeController : Controller
    {
        Context c1 = new Context();
        TraineeCourseResultViewModel TraineeCourseResultViewModel = new TraineeCourseResultViewModel();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowResult(int id, int crs)
        {
            //Trainee? trainee = c1.Trainee.FirstOrDefault(t => t.Id == id);
            //if (trainee != null)
            //{
            //    TraineeCourseResultViewModel.TraineeName = trainee.Name;
            //}
            //else
            //{

            //    return Content("This Trainee ID is not valid");
            //}
            //Course? course = c1.Course.FirstOrDefault(c => c.Id == crs);
            //if (course != null)
            //{
            //    TraineeCourseResultViewModel.CourseName = course.Name;
            //}
            //else
            //{
            //    return Content("This Course ID is not valid");
            //}

            crsResult? crsResult = c1.CrsResult.Include(cr=>cr.Course).Include(cr => cr.Trainee).FirstOrDefault(cr => (cr.CourseID == crs && cr.TraineeID == id));
            if (crsResult != null)
            {
                if (crsResult.Trainee != null)
                {
                    TraineeCourseResultViewModel.TraineeName = crsResult.Trainee.Name;
                }
                else
                {

                    return Content("This Trainee ID is not valid");
                }
                if (crsResult.Course != null)
                {
                    TraineeCourseResultViewModel.CourseName = crsResult.Course.Name;
                }
                else
                {
                    return Content("This Course ID is not valid");
                }
                TraineeCourseResultViewModel.CourseDegree = crsResult.Degree;
                if(TraineeCourseResultViewModel.CourseDegree>60)
                {
                    TraineeCourseResultViewModel.ResultColor = "green";
                }
                else 
                {
                    TraineeCourseResultViewModel.ResultColor = "red";
                }
            }
            else {
                return Content("This Result is not valid");
            }

            return View(TraineeCourseResultViewModel);
        }

        public IActionResult ShowTraineeResult(int id)
        {
            TraineeResultViewModel traineeResultViewModel = new TraineeResultViewModel();

           Trainee? t = c1.Trainee
                .Where(t1=>t1.Id == id)
                .Include(t1 => t1.CrsResult)
                .ThenInclude(cr => cr.Course)
                .FirstOrDefault();
            if (t == null)
            {
                return Content("This trainee is deleted or not registered with us.");
            }
            else
            { 
                traineeResultViewModel.Name = t.Name;
                traineeResultViewModel.Image = t.Image;
                if (t.CrsResult == null)
                {
                    return Content("this trainee does not have results");
                }
                else
                {
                    traineeResultViewModel.Crs = t.CrsResult;
                    return View(traineeResultViewModel);
                }
            }
        }
    }
}
