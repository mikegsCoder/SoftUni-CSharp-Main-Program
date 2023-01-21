using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebServer.Controllers;
using MyWebServer.Http;
using Git.ViewModels.User;
using Git.Services.UserService;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Home/Index");
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

            return Redirect("/Repositories/All");
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Home/Index");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterViewModel user)
        {
            var errors = userService.Register(user);

            if (errors.Any())
            {
                return Redirect("/Users/Register");
            }

            return Redirect("/Users/Login");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
