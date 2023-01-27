using Git.ViewModels.Commit;
using Git.ViewModels.Repository;
using System.Collections.Generic;

namespace Git.Services.RepositoryService
{
    public interface IRepositoryService
    {
        public AllRepositoriesViewModel GetAllPublic();

        IEnumerable<string> CreateRepo(CreateRepositoryViewModel model, string userId);

        public CreateCommitViewModel GetRepo(string id);
    }
}
