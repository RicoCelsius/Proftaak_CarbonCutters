using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CarbonCuttersCore;
using CarbonCuttersView.Models;

namespace CarbonCuttersView.Controllers
{
    public class ProfileController : Controller
    {
        [Authorize]
        public IActionResult Index(ProfileModel model)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value.ToString();
            model.Id = userId;


            var scoreDataList = new List<ScoreData>
            {
                new ScoreData { Date = new DateTime(2023, 5, 1), Score = 80 },
                new ScoreData { Date = new DateTime(2023, 5, 2), Score = 85 },
                new ScoreData { Date = new DateTime(2023, 5, 3), Score = 90 },
                new ScoreData { Date = new DateTime(2023, 5, 4), Score = 95 },
                new ScoreData { Date = new DateTime(2023, 5, 5), Score = 100 }
            };
            model.ScoreDataList = scoreDataList;



            return View(model);
        }
    }
}
