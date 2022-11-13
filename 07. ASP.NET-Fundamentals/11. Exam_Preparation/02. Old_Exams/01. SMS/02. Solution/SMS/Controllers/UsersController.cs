using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Services.UserService;
using SMS.ViewModels;
using SMS.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(
            IUserService _userService)
        {
            userService = _userService;
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
                ErrorViewModel model = new ErrorViewModel()
                {
                    ErrorMessage = String.Join(", ", errors)
                };

                return View(model, "/Error");
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
