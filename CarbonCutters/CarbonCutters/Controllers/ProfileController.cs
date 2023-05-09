using CarbonCuttersDAL;
using CarbonCuttersCore;
using CarbonCuttersView.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CarbonCuttersCore;
using CarbonCuttersView.Models;

namespace CarbonCuttersView.Controllers
{
    public class ProfileController : Controller
    {
        private UserCollectionDal _userCollectionDal = new();
        private TripCollectionDal  _tripCollectionDal = new();

        [Authorize]
        public IActionResult Index(ProfileModel model)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            List<Trip> trips = _tripCollectionDal.GetTripsFromDB(userId);
            List<ScoreData> scoreDataList = new List<ScoreData>();

            foreach (Trip trip in trips)
            {
                ScoreData data = new ScoreData(trip.dateTime,trip.points);
                scoreDataList.Add(data);
            }
            

            model.ScoreDataList = scoreDataList;

            return View(model);
        }
    }
}
