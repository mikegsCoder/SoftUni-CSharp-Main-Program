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
    }
}
