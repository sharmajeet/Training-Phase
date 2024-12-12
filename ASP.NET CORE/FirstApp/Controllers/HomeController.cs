using System.Diagnostics;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Home/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Home/About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("Home/Details/{id}")]
        public int Detaills(int? id)
        {
            return id ?? 1;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
