using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.ViewModels;
using SMS.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        [Authorize]
        public HttpResponse Create()
        {
            return View();
        }
    }
}
