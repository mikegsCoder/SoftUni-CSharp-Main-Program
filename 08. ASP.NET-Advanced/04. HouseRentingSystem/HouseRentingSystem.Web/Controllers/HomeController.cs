using HouseRentingSystem.Services.Houses;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseService houses;
        public HomeController(IHouseService houses)
            => this.houses = houses;

        public IActionResult Index()
        {
            var houses = this.houses.LastThreeHouses();
            return View(houses);
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