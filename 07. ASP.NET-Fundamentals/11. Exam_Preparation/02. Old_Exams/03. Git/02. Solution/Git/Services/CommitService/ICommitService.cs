using Git.ViewModels.Commit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services.CommitService
{
    public interface ICommitService
    {
        AllCommitsViewModel GetAll(string userId);
    }
}
