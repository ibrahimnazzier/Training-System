using System.Diagnostics;
using Day1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult IsEven(int id)
        {
            if (id % 2 == 0)
            {
                ViewResult MyView = new ViewResult();
                MyView.ViewName = "MyPage";
                return MyView;
            }
            else
            {
                //ContentResult content = new ContentResult();
                //content.Content = "Hello From the first MVC Project";
                return Content("Hello From the first MVC Project");
            }

        }
    }
}
