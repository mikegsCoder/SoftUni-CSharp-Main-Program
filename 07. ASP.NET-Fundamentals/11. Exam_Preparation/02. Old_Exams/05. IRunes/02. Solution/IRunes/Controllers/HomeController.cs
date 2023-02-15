using IRunes.Services.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace IRunes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService _usersService)
        {
            usersService = _usersService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (IsUserSignedIn())
            {
                var userId = GetUserId();

                var viewModel = usersService.GetHomeViewModel(userId);

                return View(viewModel, "/Home");
            }

            return View();
        }
    }
}
