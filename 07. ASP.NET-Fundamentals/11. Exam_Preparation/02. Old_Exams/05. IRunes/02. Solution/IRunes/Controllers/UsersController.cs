﻿using IRunes.Services.Users;
using IRunes.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;

namespace IRunes.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService _usersService)
        {
            usersService = _usersService;
        }

        public HttpResponse Login()
        {
            if (IsUserSignedIn())
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel login)
        {
            if (IsUserSignedIn())
            {
                return Redirect("/");
            }

            var userId = usersService.GetUserId(login);

            if (userId == null)
            {
                return Redirect("/Users/Login");
            }

            SignIn(userId);

            return Redirect("/");
        }

        public HttpResponse Register()
        {
            if (IsUserSignedIn())
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel register)
        {
            if (IsUserSignedIn())
            {
                return Redirect("/");
            }

            if (string.IsNullOrEmpty(register.Username)
                || register.Username.Length < 4
                || register.Username.Length > 10)
            {
                return Error("Name should be between 5 and 20 characters");
            }

            if (string.IsNullOrEmpty(register.Email)
                || !new EmailAddressAttribute().IsValid(register.Email))
            {
                return Error("Email is required");
            }

            if (string.IsNullOrEmpty(register.Password)
                || register.Password.Length < 6
                || register.Password.Length > 20)
            {
                return Error("Password should be between 6 and 20 characters");
            }

            if (!usersService.IsUsernameAvailable(register))
            {
                return Error("Username not available");
            }

            if (!usersService.IsEmailAvailable(register))
            {
                return Error("Email not available");
            }

            if (register.ConfirmPassword != register.Password)
            {
                return Error("Passwords do not match");
            }

            usersService.Create(register);

            return Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (IsUserSignedIn())
            {
                SignOut();
            }

            return Redirect("/");
        }
    }
}
