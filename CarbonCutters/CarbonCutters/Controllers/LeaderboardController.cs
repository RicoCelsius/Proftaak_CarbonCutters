using CarbonCuttersDAL;
using CarbonCuttersCore;
using CarbonCuttersView.Models;
using Microsoft.AspNetCore.Mvc;
using CarbonCuttersMockData;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CarbonCuttersView.Controllers;

public class LeaderboardController : Controller
{
    private UserCollection UserCollection = new(new UserCollectionDal());
    [Authorize]
    public IActionResult Index()
    {
        LeaderBoardModel model = new();
        model._users = UserCollection.GetSortedUsersByScore();
        model.user_id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

        // Find the place of the user
        var user = model._users.FindIndex(u => u.id == model.user_id);
        model.user_place = user + 1;

        model.start_i = model.user_place;
        return View(model);
    }

}
