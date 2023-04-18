using CarbonCuttersDAL;
using CarbonCuttersCore;
using CarbonCuttersView.Models;
using Microsoft.AspNetCore.Mvc;
using CarbonCuttersMockData;
using System.Security.Claims;

namespace CarbonCuttersView.Controllers;

public class LeaderboardController : Controller
{
    private UserCollection UserCollection = new(new MockUsers(30, 50));

    public IActionResult Index()
    {
        LeaderBoardModel model = new();
        model._users = UserCollection.GetSortedUsersByScore();
        model.user_id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        model.user_place = (int)Math.Ceiling((double)UserCollection.users.Count / 2);
        model.start_i = model.user_place + 3;
        return View(model);
    }
}
