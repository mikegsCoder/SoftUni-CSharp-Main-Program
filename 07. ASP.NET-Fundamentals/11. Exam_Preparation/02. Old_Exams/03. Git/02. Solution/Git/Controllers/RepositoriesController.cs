using Git.Services.RepositoryService;
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
        private readonly IRepositoryService service;
        public RepositoriesController(IRepositoryService _service)
        {
            service = _service;
        }

        public HttpResponse All()
        {
            var model = service.GetAllPublic();

            return View(model);
        }

        public HttpResponse Create()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            return View();
        }
    }
}
