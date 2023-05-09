using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

            return View(model);
        }
    }
}
