﻿using Git.Data.Models;
using Git.ViewModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services.RepositoryService
{
    public interface IRepositoryService
    {
        public AllRepositoriesViewModel GetAllPublic();
    }
}
