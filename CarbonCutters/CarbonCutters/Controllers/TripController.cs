using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
    public class TripController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            TripModel model = new TripModel();
            model.userCollection = new MockUsers(30, 100);
            return View(model);
        }
    }
}
