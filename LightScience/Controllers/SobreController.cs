using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LightScience.Controllers
{
	public class SobreController : Controller
	{
		[Authorize]
		public IActionResult Sobre()
		{
			return View();
		}
	}
}
