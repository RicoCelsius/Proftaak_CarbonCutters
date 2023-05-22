using CarbonCuttersCore;
using CarbonCuttersDAL;
using CarbonCuttersView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CarbonCuttersView.Controllers
{
    public class TripController : Controller
    {
        VehicleCollectionDal vehicles = new VehicleCollectionDal();
        VehicleCollection VehicleCollection = new VehicleCollection();

        [Authorize]
        public IActionResult Index()
        {
            string user_id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            TripCollection trips = new TripCollection(new TripCollectionDal(user_id, vehicles));
            TripsModel model = new();
            model.trips = trips.TripList;
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddTrip()
        {
            TripsModel model = new();

            string user_id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            TripCollection trips = new TripCollection(new TripCollectionDal(user_id, vehicles));
            model.trips = trips.TripList;

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddTrip(TripsModel model)
        {
            string user_id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            TripCollection trips = new TripCollection(new TripCollectionDal(user_id, vehicles));
            List<TripSegment> segments = new();
            for (int i = 1; i < model.distance.Count(); i++)
            {
                Vehicle vehicle = VehicleCollection.GetObject(model.vehicletype[i], model.size[i], model.fuel[i], model.type1[i], model.type2[i]);
                TimeOnly start = TimeOnly.Parse(model.startTime[i]);
                TimeOnly end = TimeOnly.Parse(model.endTime[i]);
                segments.Add(new TripSegment(model.distance[i], vehicle, start, end));
            }

            DateOnly date = DateOnly.Parse(model.date);
            trips.add(new Trip(segments, false, date));

            return RedirectToAction("Index");
        }
    }

}
