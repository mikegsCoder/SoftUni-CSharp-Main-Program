using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}