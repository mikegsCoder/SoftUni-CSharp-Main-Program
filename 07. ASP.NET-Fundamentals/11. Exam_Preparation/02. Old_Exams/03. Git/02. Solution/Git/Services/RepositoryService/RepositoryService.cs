using Git.Data.Common;
using Git.Data.Models;
using Git.ViewModels.Commit;
using Git.ViewModels.Repository;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository = Git.Data.Models.Repository;

namespace Git.Services.RepositoryService
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IRepository repo;

        public RepositoryService(IRepository _repo)
        {
            repo = _repo;
        }

        public AllRepositoriesViewModel GetAllPublic()
        {
            var viewModel = new AllRepositoriesViewModel
            {
                AllRepositoryViewModels = repo.All<Repository>()
                        .Where(r => r.IsPublic)
                        .Select(r => new RepositoryViewModel()
                        {
                            Name = r.Name,
                            Owner = r.Owner.Username,
                            CreatedOn = r.CreatedOn.ToString("dd/MM/yyyy hh:mm:ss"),
                            CommitsCount = r.Commits.Count,
                            Id = r.Id
                        })
                        .ToList()
            };

            return viewModel;
        }

        public IEnumerable<string> CreateRepo(CreateRepositoryViewModel model, string userId)
        {
            var errors = new List<string>();

            if (model.Name.Length < 3 || model.Name.Length > 10)
            {
                errors.Add("Repo name must be between 3 and 10 characters long");

                return errors;
            }

            Repository repository = new Repository()
            {
                Name = model.Name,
                CreatedOn = DateTime.Now,
                IsPublic = model.RepositoryType == "Public" ? true : false,
                OwnerId = userId,
            };

            try
            {
                repo.Add(repository);
                repo.SaveChanges();
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }

            return errors;
        }

        public CreateCommitViewModel GetRepo(string id)
        {
            return repo
                .All<Data.Models.Repository>()
                .Select(x => new CreateCommitViewModel
                {
                    Name = x.Name,
                    Id = x.Id
                })
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
