using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
