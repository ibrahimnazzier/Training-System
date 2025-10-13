using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    public class PassDataController : Controller
    {
        public IActionResult SendData()
        {
            HttpContext.Session.SetString("Name","Ali");
            HttpContext.Session.SetInt32("Age", 27);
            return Content("Session Saved");
        }
        public IActionResult GetSession()
        {
            string? name = HttpContext.Session.GetString("Name");
            int? Age = HttpContext.Session.GetInt32("Age");
            return Content($"Session User: {name}, its age {Age}.");
        }
    }
}
