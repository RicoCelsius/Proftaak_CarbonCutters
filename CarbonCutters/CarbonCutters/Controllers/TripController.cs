using CarbonCuttersCore;
using CarbonCuttersDAL;
using CarbonCuttersMockData;
using CarbonCuttersView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarbonCuttersView.Controllers
{
    public class TripController : Controller
    {
        VehicleCollectionDal vehicles = new VehicleCollectionDal();

        public IActionResult Index()
        {
            string user_id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            TripCollection trips = new TripCollection(new TripCollectionDal(user_id, vehicles));
            TripsModel model = new();
            model.trips = trips.TripList;
            return View(model);
        }

        [HttpGet]
        public IActionResult AddTrip(TripsModel model)
        {
            string user_id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            TripCollection trips = new TripCollection(new TripCollectionDal(user_id, vehicles));
            model.trips = trips.TripList;

            return View(model);
        }

        [HttpPost]
        public IActionResult AddTrip(TripModel model)
        {
            return RedirectToAction("Index");
        }
    }

}
