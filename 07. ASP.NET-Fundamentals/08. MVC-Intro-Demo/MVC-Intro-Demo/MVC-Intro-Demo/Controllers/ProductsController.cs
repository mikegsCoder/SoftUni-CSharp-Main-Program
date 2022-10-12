using Microsoft.AspNetCore.Mvc;

namespace MVC_Intro_Demo.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
