using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
    public class Tripcontroller : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

    }
}
