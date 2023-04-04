using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarbonCuttersView.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            ViewBag.UserId = userId;



            /*using (var db = new MyDbContext()
            {
                var userExists = db.Users.Any(u => u.UserId == userId);

                if (userExists)
                {
                    // The user exists in the database
                    // ..
                }
                else
                {
                    // The user does not exist in the database
                    // ...
                }
            }*/

            return View();
        }
    }
}
