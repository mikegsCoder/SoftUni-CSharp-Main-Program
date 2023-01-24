using Git.Data.Common;
using Git.Data.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services.CommitService
{
    public class CommitService : ICommitService
    {
        private readonly IRepository repo;

        public CommitService(IRepository _repo)
        {
            repo = _repo;
        }

        public AllCommitsViewModel GetAll(string userId)
        {
            var viewmodel = new AllCommitsViewModel()
            {
                AllCommitsViewModels = repo
                .All<Commit>()
                .Where(x => x.CreatorId == userId)
                .Select(x => new CommitViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    RepositoryName = x.Repository.Name,
                    CreatedOn = x.CreatedOn.ToString("d"),
                })
                .AsEnumerable()
            };

            return viewmodel;
        }
    }
}

