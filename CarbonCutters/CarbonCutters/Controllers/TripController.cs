using CarbonCuttersMockData;
using CarbonCuttersView.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
    public class TripController : Controller
    {
        public IActionResult Index()
        {
            TripModel model = new TripModel();
            model.userCollection = new MockUsers(30, 100);
            return View(model);
        }
    }
}
