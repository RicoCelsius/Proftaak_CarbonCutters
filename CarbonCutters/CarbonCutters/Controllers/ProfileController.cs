using CarbonCuttersDAL;
using CarbonCuttersCore;
using CarbonCuttersView.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json.Serialization;

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
            TripCollection tripcollection = new TripCollection(_tripCollectionDal);
           
            List<Trip> trips = _tripCollectionDal.GetTripsFromDB(userId);
            UserCollection usercollection = new UserCollection(_userCollectionDal);
            User user = usercollection.get(userId);
            model.Name = user.name;
            model.Picture = user.picture;
            model.Score = tripcollection.CalculateTotalScoreOfUser(userId);
            model.AverageScoreDataList = tripcollection.CalculateAverageScoreOfAllUsers();
            model.ScoreDataList = tripcollection.CalculateAverageScoreOfUser(userId);

            return View(model);
        }
    }
}
