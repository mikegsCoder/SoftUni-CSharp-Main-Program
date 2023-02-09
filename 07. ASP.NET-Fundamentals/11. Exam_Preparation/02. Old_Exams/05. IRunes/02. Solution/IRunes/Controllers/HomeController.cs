using SUS.HTTP;
using SUS.MvcFramework;

namespace IRunes.Controllers
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
