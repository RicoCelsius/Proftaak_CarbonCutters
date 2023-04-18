using CarbonCuttersDAL;
using CarbonCuttersCore;
using CarbonCuttersView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarbonCuttersView.Controllers;

public class LeaderboardController : Controller
{
    private UserCollection UserCollection = new(new UserCollectionDal());

    public IActionResult Index()
    {
        LeaderBoardModel model = new();
        model.user_id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        model._users = UserCollection.GetSortedUsersByScore();
        return View(model);
    }
}
