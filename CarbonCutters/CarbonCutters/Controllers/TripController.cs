using CarbonCuttersCore;
using CarbonCuttersMockData;
using CarbonCuttersView.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
    public class Tripcontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTrip(TripModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult AddTrip(AddTripModel model)
        {
            return RedirectToAction("Index");
        }
    }
}
