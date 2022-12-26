using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}