using System.Collections.Generic;

namespace Git.ViewModels.Repository
{
    public class AllRepositoriesViewModel
    {
        public IEnumerable<RepositoryViewModel> AllRepositoryViewModels { get; set; }
    }
}
