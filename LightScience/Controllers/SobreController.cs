using Microsoft.AspNetCore.Mvc;

namespace LightScence.Controllers
{
	public class SobreController : Controller
	{
		public IActionResult Sobre()
		{
			return View();
		}
	}
}
