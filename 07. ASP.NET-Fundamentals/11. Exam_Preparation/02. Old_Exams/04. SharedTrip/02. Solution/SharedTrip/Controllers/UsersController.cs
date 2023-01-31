using System.Linq;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginViewModel user)
        {
            var userId = userService.Login(user);

            if (userId == null)
            {
                return Redirect("/Users/Login");
            }

            SignIn(userId);

            return Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Home/Index");
            }

            return View();
        }
    }
}
