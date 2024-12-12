using Microsoft.AspNetCore.Mvc;

namespace Routing_Without_MVC.Controller
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
