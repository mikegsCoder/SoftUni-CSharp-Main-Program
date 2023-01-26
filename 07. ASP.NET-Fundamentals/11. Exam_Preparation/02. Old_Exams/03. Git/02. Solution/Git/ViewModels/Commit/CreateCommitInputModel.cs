using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.ViewModels.Commit
{
    public class CreateCommitInputModel
    {
        public string Description { get; set; }

        public string Id { get; set; }

        public string CreatorId { get; set; } = string.Empty;

        //public string RepositoryId { get; set; } = string.Empty;
    }
}
