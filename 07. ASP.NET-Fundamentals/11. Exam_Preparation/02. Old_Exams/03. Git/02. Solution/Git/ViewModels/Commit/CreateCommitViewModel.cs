using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.ViewModels.Commit
{
    public class CreateCommitViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
