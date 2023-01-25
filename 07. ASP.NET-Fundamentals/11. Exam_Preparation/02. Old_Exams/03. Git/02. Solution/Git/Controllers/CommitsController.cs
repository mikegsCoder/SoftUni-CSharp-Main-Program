using Git.Services.CommitService;
using Git.Services.RepositoryService;
using Git.Services.ValidationService;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;
        private readonly IRepositoryService repositoryService;

        public CommitsController(
            ICommitService _commitService,
            IRepositoryService _repositoryService)
        {
            commitService = _commitService;
            repositoryService = _repositoryService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var models = this.commitService.GetAll(this.User.Id);

            return this.View(models);
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var viewModel = this.repositoryService.GetRepo(id);

            return this.View(viewModel);
        }
    }
}
