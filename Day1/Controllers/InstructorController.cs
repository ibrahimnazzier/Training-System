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
        public IActionResult 
    }
    
}
