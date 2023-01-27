using Git.ViewModels.Commit;
using System.Collections.Generic;

namespace Git.Services.CommitService
{
    public interface ICommitService
    {
        AllCommitsViewModel GetAll(string userId);

        IEnumerable<string> Create(CreateCommitInputModel model);

        public void Delete(string id, string userId);
    }
}
