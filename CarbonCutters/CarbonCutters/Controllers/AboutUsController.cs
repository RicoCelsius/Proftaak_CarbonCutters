using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
    public class AboutUsController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
