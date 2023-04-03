using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
