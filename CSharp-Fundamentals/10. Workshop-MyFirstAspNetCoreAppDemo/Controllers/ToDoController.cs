using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreAppDemo.Controllers
{
    public class ToDoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HelloMessage = "Welcome to /ToDo/Index";
            return View();
        }
    }
}
