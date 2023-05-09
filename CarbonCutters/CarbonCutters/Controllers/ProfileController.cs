using CarbonCuttersDAL;
using CarbonCuttersCore;
using CarbonCuttersView.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarbonCuttersView.Controllers
{
    public class ProfileController : Controller
    {
        private UserCollectionDal _userCollectionDal = new();

        [Authorize]
        public IActionResult Index()
        {
            ProfileModel model = new ProfileModel();
            model.user_id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            model.user = new UserCollection(_userCollectionDal).get(model.user_id);

            return View(model);
        }
    }
}
