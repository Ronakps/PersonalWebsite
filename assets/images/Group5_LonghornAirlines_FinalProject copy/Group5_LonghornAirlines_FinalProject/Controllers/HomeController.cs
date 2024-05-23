using Group5_LonghornAirlines_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group5_LonghornAirlines_FinalProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Flights");
        }
    }
}
