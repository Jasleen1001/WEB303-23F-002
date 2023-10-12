using Microsoft.AspNetCore.Mvc;

namespace Jasleen.Controllers
{
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Todolist(int id, string Jtitle, string description)
        {
            ViewData["Id"] = id;
            ViewData["Jtitle"] = Jtitle;
            ViewData["Description"] = description;
            return View();
        }
    }
}
