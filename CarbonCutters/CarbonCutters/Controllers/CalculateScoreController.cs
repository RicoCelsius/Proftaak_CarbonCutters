using CarbonCuttersCore;
using Microsoft.AspNetCore.Mvc;

namespace CarbonCuttersView.Controllers
{
    public class CalculateScoreController : Controller
    {
        public ActionResult CalculateScore(int distance, string group, string method)
        {
            int points = Score.CalculateScore(distance, group, method);
            ViewBag.Points = points;
            return View();
        }
    }
}
