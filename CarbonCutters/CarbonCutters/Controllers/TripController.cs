using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
    public class Tripcontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
