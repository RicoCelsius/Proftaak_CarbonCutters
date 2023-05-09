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

        [Authorize]
        public IActionResult Index(ProfileModel model)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            ViewBag.UserId = userId;

            return View(model);
        }
    }
}
