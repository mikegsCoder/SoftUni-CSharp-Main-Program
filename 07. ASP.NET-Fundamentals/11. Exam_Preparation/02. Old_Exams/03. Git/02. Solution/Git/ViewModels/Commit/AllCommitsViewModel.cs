using System.Collections.Generic;

namespace Git.ViewModels.Commit
{
    public class AllCommitsViewModel
    {
        public IEnumerable<CommitViewModel> AllCommitsViewModels { get; set; }
    }
}
