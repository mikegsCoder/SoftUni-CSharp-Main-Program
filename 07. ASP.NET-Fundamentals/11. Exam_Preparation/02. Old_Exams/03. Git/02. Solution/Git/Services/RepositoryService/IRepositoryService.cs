using Git.Data.Models;
using Git.ViewModels.Commit;
using Git.ViewModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services.RepositoryService
{
    public interface IRepositoryService
    {
        public AllRepositoriesViewModel GetAllPublic();

        IEnumerable<string> CreateRepo(CreateRepositoryViewModel model, string userId);

        public CreateCommitViewModel GetRepo(string id);
    }
}
