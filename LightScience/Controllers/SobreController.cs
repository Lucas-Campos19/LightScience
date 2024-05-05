using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LightScence.Controllers
{
	public class SobreController : Controller
	{
		[Authorize]
		public IActionResult Index()
		{
			return View();
		}
	}
}
