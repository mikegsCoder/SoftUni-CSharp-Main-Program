using Git.Services.RepositoryService;
using Git.ViewModels.Repository;
using MyWebServer.Controllers;
using MyWebServer.Http;

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

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateRepositoryViewModel model)
        {
            var errors = service.CreateRepo(model, User.Id);

            return Redirect("/Repositories/All");
        }
    }
}
