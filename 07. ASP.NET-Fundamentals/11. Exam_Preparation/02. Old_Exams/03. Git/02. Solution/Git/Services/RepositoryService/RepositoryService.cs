﻿using Git.Data.Common;
using Git.Data.Models;
using Git.ViewModels.Repository;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository = Git.Data.Models.Repository;

namespace Git.Services.RepositoryService
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IRepository repo;

        public RepositoryService(IRepository _repo)
        {
            repo = _repo;
        }

        public AllRepositoriesViewModel GetAllPublic()
        {
            var viewModel = new AllRepositoriesViewModel
            {
                AllRepositoryViewModels = repo.All<Repository>()
                        .Where(r => r.IsPublic)
                        .Select(r => new RepositoryViewModel()
                        {
                            Name = r.Name,
                            Owner = r.Owner.Username,
                            CreatedOn = r.CreatedOn.ToString("dd/MM/yyyy hh:mm:ss"),
                            CommitsCount = r.Commits.Count,
                            Id = r.Id
                        })
                        .ToList()
            };

            return viewModel;
        }
    }
}
