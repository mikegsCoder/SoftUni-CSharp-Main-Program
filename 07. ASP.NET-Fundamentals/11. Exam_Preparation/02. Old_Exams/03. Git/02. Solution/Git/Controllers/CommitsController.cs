using Git.Services.CommitService;
using Git.Services.RepositoryService;
using Git.Services.ValidationService;
using Git.ViewModels.Commit;
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
        private readonly IValidationService validatorService;
        private readonly IRepositoryService repositoryService;

        public CommitsController(
            ICommitService _commitService,
            IValidationService _validationService,
            IRepositoryService _repositoryService)
        {
            commitService = _commitService;
            validatorService = _validationService;
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

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateCommitInputModel model)
        {
            var errors = this.validatorService.ValidateModel(model);

            if (errors.Any())
            {
                return this.Redirect($"/Commits/Create?id={model.Id}");
            }

            model.CreatorId = this.User.Id;

            this.commitService.Create(model);

            return this.Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            this.commitService.Delete(id, this.User.Id);

            return this.Redirect("/Commits/All");
        }
    }
}
