using Microsoft.AspNetCore.Mvc;

namespace Routing_Without_MVC.Controllers // Use "Controllers" instead of "Controller"
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
