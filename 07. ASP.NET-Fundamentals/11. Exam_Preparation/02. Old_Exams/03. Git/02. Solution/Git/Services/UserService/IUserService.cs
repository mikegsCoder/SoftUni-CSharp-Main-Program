using Git.ViewModels.User;
using System.Collections.Generic;

namespace Git.Services.UserService
{
    public interface IUserService
    {
        string Login(LoginViewModel model);

        ICollection<string> Register(RegisterViewModel model);
    }
}
