using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.ViewModels.Repository
{
    public class RepositoryViewModel
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string CreatedOn { get; set; }
        public int CommitsCount { get; set; }
        public string Id { get; set; }
    }
}
