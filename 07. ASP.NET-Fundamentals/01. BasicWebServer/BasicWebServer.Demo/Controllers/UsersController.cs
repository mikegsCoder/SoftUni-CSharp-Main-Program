using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Controllers;

namespace BasicWebServer.Demo.Controllers
{
    public class UsersController : Controller
    {
        public UsersController(Request request) 
            : base(request)
        {
        }
    }
}
