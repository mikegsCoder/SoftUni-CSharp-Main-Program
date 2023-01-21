using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        public HttpResponse All()
        {
            var model = service.GetAllPublic();

            return View(model);
        }
    }
}
