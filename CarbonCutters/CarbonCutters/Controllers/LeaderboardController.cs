using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
	public class LeaderboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
