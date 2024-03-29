﻿using Git.Data.Common;
using Git.Data.Models;
using Git.ViewModels.Commit;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<string> Create(CreateCommitInputModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length < 5)
            {
                errors.Add("Description must be at least 5 characters long.");

                return errors;
            }

            var commit = new Commit()
            {
                Description = model.Description,
                CreatedOn = DateTime.Now,
                CreatorId = model.CreatorId,
                RepositoryId = model.Id
            };

            try
            {
                repo.Add(commit);
                repo.SaveChanges();
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }

            return errors;
        }

        public void Delete(string id, string userId)
        {
            var coomit = this.repo
                .All<Commit>()
                .FirstOrDefault(x => x.Id == id && x.CreatorId == userId);

            this.repo.Remove(coomit);
            this.repo.SaveChanges();
        }
    }
}
