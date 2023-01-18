using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebServer.Controllers;
using MyWebServer.Http;
using Git.ViewModels.User;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Home/Index");
            }

            return View();
        }
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

        return Redirect("/Repositories/All");
    }
}
