using Microsoft.AspNetCore.Mvc;

namespace LightScience.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
