using CarbonCuttersDAL;
using CarbonCuttersCore;
using CarbonCuttersView.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json.Serialization;
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
            UserCollection usercollection = new UserCollection(_userCollectionDal);
            List<ScoreData> scoreDataList = new List<ScoreData>();
            User user = usercollection.get(userId);
            model.Name = user.name;
            model.Picture = user.picture;

            foreach (Trip trip in trips)
            {
                ScoreData data = new ScoreData(trip.dateTime.ToString(),trip.points);
                scoreDataList.Add(data);
            }
           


            model.ScoreDataList = scoreDataList;

            return View(model);
        }
    }
}
