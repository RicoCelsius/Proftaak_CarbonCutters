using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
