using SMS.Data.Models;
using SMS.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.UserService
{
    public interface IUserService
    {
        ICollection<string> Register(RegisterViewModel model);
    }
}
