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

        public CommitsController(ICommitService _commitService)
        {
            commitService = _commitService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var models = this.commitService.GetAll(this.User.Id);

            return this.View(models);
        }
    }
}
