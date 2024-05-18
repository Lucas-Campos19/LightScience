using Microsoft.AspNetCore.Mvc;

namespace LightScience.Controllers
{
	public class SobreController : Controller
	{
		public IActionResult Sobre()
		{
			return View();
		}
	}
}
