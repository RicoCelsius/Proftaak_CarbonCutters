using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
    public class LeaderboardController : Controller
    {
<<<<<<< HEAD
        [Authorize]
=======
>>>>>>> frontend-index&addtrip
        public IActionResult Index()
        {
            return View();
        }
    }
}
