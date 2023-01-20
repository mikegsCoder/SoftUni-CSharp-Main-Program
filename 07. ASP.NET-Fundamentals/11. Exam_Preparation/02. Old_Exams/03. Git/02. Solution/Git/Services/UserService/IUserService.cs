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

        ICollection<string> Register(RegisterViewModel model);

        string Hash(string password);
    }
}
