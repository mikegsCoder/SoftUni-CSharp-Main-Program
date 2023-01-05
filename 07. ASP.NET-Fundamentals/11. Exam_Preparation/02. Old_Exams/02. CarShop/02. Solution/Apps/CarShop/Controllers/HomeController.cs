using SUS.HTTP;
using SUS.MvcFramework;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
