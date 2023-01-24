using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.ViewModels.Commit
{
    public class AllCommitsViewModel
    {
        public IEnumerable<CommitViewModel> AllCommitsViewModels { get; set; }
    }
}
