using Microsoft.AspNetCore.Mvc;

namespace GoldwallApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Simple About page for now
        public IActionResult About()
        {
            return View();
        }
    }
}