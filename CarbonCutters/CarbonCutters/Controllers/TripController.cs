using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
    public class TripController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
