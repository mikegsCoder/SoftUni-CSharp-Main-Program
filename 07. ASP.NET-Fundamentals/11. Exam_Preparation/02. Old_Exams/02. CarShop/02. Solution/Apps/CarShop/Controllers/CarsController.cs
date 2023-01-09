using CarShop.Services;
using CarShop.Services.Cars;
using CarShop.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Text.RegularExpressions;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;

        public CarsController(
            ICarsService carService,
            IUsersService usersService)
        {
            this.carsService = carService;
            this.usersService = usersService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            string userId = this.GetUserId();
            var isUserMechanic = this.usersService.IsUserMechanic(userId);

            if (isUserMechanic)
            {
                var viewModel = this.carsService.GetAllCarsForNechanics();
                return this.View(viewModel);
            }
            else
            {
                var viewModel = this.carsService.GetAllCars(userId);
                return this.View(viewModel);
            }
        }
    }
}
