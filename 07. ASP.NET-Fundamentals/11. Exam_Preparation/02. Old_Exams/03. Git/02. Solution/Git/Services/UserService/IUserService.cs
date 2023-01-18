using Git.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services.UserService
{
    public interface IUserService
    {
        string Login(LoginViewModel model);

        string Hash(string password);
    }
}
